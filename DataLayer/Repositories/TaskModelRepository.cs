using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
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

        public async Task createTask(WorkTask task) { 
            _WolfDbContext.Tasks.Add(task);
            await _WolfDbContext.SaveChangesAsync();
        }
    }
}
