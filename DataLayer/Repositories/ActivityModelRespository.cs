using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity = DataAccessLayer.Models.Activity;

namespace DataAccessLayer.Repositories
{
    public class ActivityModelRespository : IActivityModelRespository
    {
        private WolfDbContext _WolfDbContext { get; set; }
        public ActivityModelRespository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task CreateActivity(Models.Activity activity)
        {
            // Load the ActivityType entity based on ActivityTypeID
            var activityType = await _WolfDbContext.activityTypes.FindAsync(activity.ActivityTypeID);
            if (activityType == null)
            {
                throw new ArgumentException("Invalid ActivityTypeID");
            }
            activity.ActivityType = activityType;

            // Load the Request entity based on RequestId
            var request = await _WolfDbContext.Requests.FindAsync(activity.RequestId);
            if (request == null)
            {
                throw new ArgumentException("Invalid RequestId");
            }
            activity.Request = request;

            // Load the ParentActivity entity based on ParentActivityId, if it exists
            if (activity.ParentActivityId.HasValue)
            {
                var parentActivity = await _WolfDbContext.Activities.FindAsync(activity.ParentActivityId.Value);
                if (parentActivity == null)
                {
                    throw new ArgumentException("Invalid ParentActivityId");
                }
                activity.ParentActivity = parentActivity;
            }

            // Load the mainExecutant entity based on ExecutantId
            var mainExecutant = await _WolfDbContext.Employees.FindAsync(activity.ExecutantId);
            if (mainExecutant == null)
            {
                throw new ArgumentException("Invalid ExecutantId");
            }
            activity.mainExecutant = mainExecutant;

            // Check if Tasks collection is null
            if (activity.Tasks != null)
            {
                // Ensure tasks are properly loaded and linked
                foreach (var task in activity.Tasks)
                {
                    // Load the Executant entity for each task
                    var taskExecutant = await _WolfDbContext.Employees.FindAsync(task.ExecutantId);
                    if (taskExecutant == null)
                    {
                        throw new ArgumentException($"Invalid ExecutantId for TaskId {task.TaskId}");
                    }
                    task.Executant = taskExecutant;

                    // Load the Control entity for each task, if it exists
                    if (task.ControlId.HasValue)
                    {
                        var taskControl = await _WolfDbContext.Employees.FindAsync(task.ControlId.Value);
                        if (taskControl == null)
                        {
                            throw new ArgumentException($"Invalid ControlId for TaskId {task.TaskId}");
                        }
                        task.Control = taskControl;
                    }

                    // Load the TaskType entity for each task
                    var taskType = await _WolfDbContext.taskTypes.FindAsync(task.TaskTypeId);
                    if (taskType == null)
                    {
                        throw new ArgumentException($"Invalid TaskTypeId for TaskId {task.TaskId}");
                    }
                    task.taskType = taskType;
                }
            }

            // Add the activity to the DbContext and save changes
            _WolfDbContext.Activities.Add(activity);


            await _WolfDbContext.SaveChangesAsync();
        }



        public List<DataAccessLayer.Models.Activity> FindLinkedActivity(Request request)
        {
            return _WolfDbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.Tasks)
                    .ThenInclude(t => t.Executant)
                .Include(a => a.Tasks)
                    .ThenInclude(t => t.Control)
                .Include(a => a.Tasks)
                    .ThenInclude(t => t.taskType)
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.ActivityType)
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.Tasks)
                        .ThenInclude(t => t.Executant)
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.Tasks)
                        .ThenInclude(t => t.Control)
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.Tasks)
                        .ThenInclude(t => t.taskType)
                .Include(a => a.mainExecutant)
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.mainExecutant)
                .Where(a => a.RequestId == request.RequestId)
                .ToList();
        }


        public async Task<Activity> GetActivity(int id)
        {
            return await _WolfDbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.Tasks)
                    .ThenInclude(t => t.Executant)
                .Include(a => a.Tasks)
                    .ThenInclude(t => t.Control)
                .Include(a => a.Tasks)
                    .ThenInclude(t => t.taskType)
                .Include(a => a.mainExecutant)
                .FirstOrDefaultAsync(a => a.ActivityId == id);
        }

        public async Task<bool> DeleteOnRequestAsync(Request request, List<Activity> activitiesToDeleteReturn)
        {
            try
            {
                // Find the activities that have the same RequestId as the provided request
                var activitiesToDelete = await _WolfDbContext.Activities
                    .Where(a => a.RequestId == request.RequestId)
                    .ToListAsync();

                if (activitiesToDelete.Any())
                {
                    activitiesToDeleteReturn = new List<Activity>(activitiesToDelete);
                    _WolfDbContext.Activities.RemoveRange(activitiesToDelete);
                    var affectedRows = await _WolfDbContext.SaveChangesAsync();

                    // Check if any rows were affected
                    return affectedRows > 0;
                }

                // If no activities were found to delete, return true (indicating no work to do)
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging framework)
                // Example: _logger.LogError(ex, "An error occurred while deleting activities");

                // Return false to indicate failure
                return false;
            }
        }

        public async Task<bool> DeleteActivities(List<Activity> activities)
        {
            // Check if the list of activities is null or empty
            if (activities == null || activities.Count == 0)
            {
                return false;
            }

            try
            {
                // Extract ActivityIds from the list of Activity
                var activityIds = activities.Select(a => a.ActivityId).ToList();

                // Find the activities that need to be deleted
                var activitiesToDelete = _WolfDbContext.Activities
                                            .Where(a => activityIds.Contains(a.ActivityId))
                                            .ToList();

                if (activitiesToDelete == null || activitiesToDelete.Count == 0)
                {
                    return false;
                }

                // Remove the activities from the DbContext
                _WolfDbContext.Activities.RemoveRange(activitiesToDelete);

                // Save changes to the database asynchronously
                await _WolfDbContext.SaveChangesAsync();

                return true; // Indicate that the operation was successful
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                // Handle the exception as needed

                return false; // Indicate that the operation failed
            }
        }

        public async Task<bool> EditActivity(Models.Activity activity)
        {
            // Retrieve the existing activity from the database
            var existingActivity = await _WolfDbContext.Activities
                .FirstOrDefaultAsync(a => a.ActivityId == activity.ActivityId);

            // Check if the activity exists
            if (existingActivity == null)
            {
                return false; // Indicate that the activity was not found
            }

            // Update the necessary fields
            existingActivity.ActivityTypeID = activity.ActivityTypeID;
            existingActivity.ExpectedDuration = activity.ExpectedDuration;
            existingActivity.StartDate = activity.StartDate;
            existingActivity.employeePayment = activity.employeePayment;
            existingActivity.ExecutantId = activity.ExecutantId;
            existingActivity.ParentActivityId = activity.ParentActivityId;
            // Update any other fields as necessary

            // Save changes to the database
            await _WolfDbContext.SaveChangesAsync();

            return true; // Indicate that the update was successful
        }
    }
}
