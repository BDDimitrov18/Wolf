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
    public class ActivityTypesModelRepository : IActivityTypesModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public ActivityTypesModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public List<ActivityType> GetAllActivityTypes() {
            return _WolfDbContext.activityTypes
                                .Include(at => at.TaskTypes)
                                .ToList();
        }

        public async Task AddActivityTypes(List<ActivityType> activityTypes) { 
            _WolfDbContext.activityTypes.AddRange(activityTypes);
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<ActivityType> GetActivityType(int id)
        {
            return await _WolfDbContext.activityTypes.FindAsync(id);
        }
    }
}
