using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Activity_PlotRelashionshipModelRepository : IActivity_PlotRelashionshipModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public Activity_PlotRelashionshipModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task Add(Activity_PlotRelashionship relashionship) {
            _WolfDbContext.Activity_PlotRelashionships.Add(relashionship);
            await _WolfDbContext.SaveChangesAsync();
        }
    }
}
