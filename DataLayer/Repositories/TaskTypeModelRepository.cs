using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TaskTypeModelRepository: ITaskTypeModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public TaskTypeModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }
        public async Task AddTaskTypes(List<TaskType> taskTypes) { 

            _WolfDbContext.AddRange(taskTypes);
            _WolfDbContext.SaveChanges();
        }

    }
}
