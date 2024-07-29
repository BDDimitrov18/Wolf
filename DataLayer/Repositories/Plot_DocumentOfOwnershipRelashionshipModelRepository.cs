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

        public async Task AddRelashionship(Plot_DocumentOfOwnershipRelashionship relashionship)
        {
            var existingRelationship = await _WolfDbContext.Plot_DocumentOfOwnerships
                .FirstOrDefaultAsync(p => p.PlotId == relashionship.PlotId && p.DocumentOfOwnershipId == relashionship.DocumentOfOwnershipId);

            if (existingRelationship != null)
            {
                // Copy necessary fields from existing relationship to the input relationship
                relashionship.DocumentPlotId = existingRelationship.DocumentPlotId;
                relashionship.Plot = existingRelationship.Plot;
                relashionship.documentOfOwnership = existingRelationship.documentOfOwnership;
                relashionship.DocumentOfOwnershipId = existingRelationship.DocumentOfOwnershipId;
                relashionship.RowVersion = existingRelationship.RowVersion;
                return;
            }

            // Add the new plot-document relationship
            await _WolfDbContext.Plot_DocumentOfOwnerships.AddAsync(relashionship);
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<Plot_DocumentOfOwnershipRelashionship> FindById(int id) {
            return await _WolfDbContext.Plot_DocumentOfOwnerships.FindAsync(id);
        }

        public async Task<bool> onPlotOwnerDelete(int id)
        {
            try
            {
                int br = _WolfDbContext.documentPlot_DocumentOwenerRelashionships.Where(opt => opt.DocumentPlotId == id).Count();

                if (br == 0)
                {
                    _WolfDbContext.Plot_DocumentOfOwnerships.Remove(await _WolfDbContext.Plot_DocumentOfOwnerships.FindAsync(id));
                    await _WolfDbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> getIdOnPlotOwner(DocumentPlot_DocumentOwnerRelashionship relashionship)
        {
            var result = await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.FindAsync(relashionship.Id);
            if (result != null)
            {
                return result.DocumentPlotId;
            }
            return -1;
        }
    }
}
