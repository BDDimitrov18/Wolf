using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TaskModelRepository : ItaskModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public TaskModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task createTask(WorkTask task)
        {
            // Add the new task to the database context
            _WolfDbContext.Tasks.Add(task);

            // Save changes to the database asynchronously
            await _WolfDbContext.SaveChangesAsync();

            // Retrieve the newly created task with related entities
            var createdTask = await _WolfDbContext.Tasks
                .Include(t => t.Activity)                          // Include related Activity entity
                    .ThenInclude(a => a.ParentActivity)            // Include ParentActivity of the Activity
                .Include(t => t.Executant)                         // Include related Executant (Employee) entity
                .Include(t => t.Control)                           // Include related Control (Employee) entity
                .FirstOrDefaultAsync(t => t.TaskId == task.TaskId); // Find the task by TaskId
        }

        public async Task<bool> DeleteOnActivityAsync(Activity activity)
        {
            try
            {
                // Find the WorkTasks that have the same ActivityId as the provided activity
                var workTasksToDelete = await _WolfDbContext.Tasks
                    .Where(wt => wt.ActivityId == activity.ActivityId)
                    .ToListAsync();

                if (workTasksToDelete.Any())
                {
                    _WolfDbContext.Tasks.RemoveRange(workTasksToDelete);
                    var affectedRows = await _WolfDbContext.SaveChangesAsync();

                    // Check if any rows were affected
                    return affectedRows > 0;
                }

                // If no tasks were found to delete, return true (indicating no work to do)
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging framework)
                // Example: _logger.LogError(ex, "An error occurred while deleting work tasks");

                // Return false to indicate failure
                return false;
            }
        }

        public async Task<bool> DeleteTasks(List<WorkTask> tasks)
        {
            // Check if the list of tasks is null or empty
            if (tasks == null || tasks.Count == 0)
            {
                return false;
            }

            try
            {
                // Remove the tasks from the DbContext
                _WolfDbContext.Tasks.RemoveRange(tasks);

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
    }
}
