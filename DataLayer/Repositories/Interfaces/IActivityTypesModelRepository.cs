using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IActivityTypesModelRepository
    {
        public List<ActivityType> GetAllActivityTypes();

        public Task AddActivityTypes(List<ActivityType> activityTypes);

        public Task<ActivityType> GetActivityType(int id);


    }
}
