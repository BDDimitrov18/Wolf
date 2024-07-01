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
            var activityType = await _WolfDbContext.activityTypes.FindAsync(activity.ActivityTypeID);
            if (activityType == null)
            {
                throw new ArgumentException("Invalid ActivityTypeID");
            }

            // Set the ActivityType property on the activity entity
            activity.ActivityType = activityType;

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
                .Include(a => a.ParentActivity) // Include the ParentActivity
                    .ThenInclude(pa => pa.ActivityType) // Optionally include related data for ParentActivity
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.Tasks)
                        .ThenInclude(t => t.Executant)
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.Tasks)
                        .ThenInclude(t => t.Control)
                .Include(a => a.ParentActivity)
                    .ThenInclude(pa => pa.Tasks)
                        .ThenInclude(t => t.taskType)
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
        .FirstOrDefaultAsync(a => a.ActivityId == id);
        }
    }
}
