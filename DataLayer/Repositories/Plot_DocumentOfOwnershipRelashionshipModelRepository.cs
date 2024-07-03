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
    public class Plot_DocumentOfOwnershipRelashionshipModelRepository : IPlot_DocumentOfOwnershipRelashionshipModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public Plot_DocumentOfOwnershipRelashionshipModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task AddRelashionship(Plot_DocumentOfOwnershipRelashionship relashionship) {
            var existingRelationship = _WolfDbContext.Plot_DocumentOfOwnerships
                .FirstOrDefault(p => p.PlotId == relashionship.PlotId && p.DocumentOfOwnershipId == relashionship.DocumentOfOwnershipId);

            if (existingRelationship != null)
            {
                // Update the input plotDocument with existing values if they are not null or empty
                relashionship.DocumentPlotId = existingRelationship.DocumentPlotId;
                relashionship.PlotId = existingRelationship.PlotId != 0 ? existingRelationship.PlotId : relashionship.PlotId;
                relashionship.Plot = existingRelationship.Plot ?? relashionship.Plot;
                relashionship.DocumentOfOwnershipId = existingRelationship.DocumentOfOwnershipId != 0 ? existingRelationship.DocumentOfOwnershipId : relashionship.DocumentOfOwnershipId;
                relashionship.documentOfOwnership = existingRelationship.documentOfOwnership ?? relashionship.documentOfOwnership;
            }
            else
            {
                // Add the new plot-document relationship
                _WolfDbContext.Plot_DocumentOfOwnerships.Add(relashionship);
                await _WolfDbContext.SaveChangesAsync();
            }
        }

        public async Task<Plot_DocumentOfOwnershipRelashionship> FindById(int id) {
            return await _WolfDbContext.Plot_DocumentOfOwnerships.FindAsync(id);
        }
    }
}
