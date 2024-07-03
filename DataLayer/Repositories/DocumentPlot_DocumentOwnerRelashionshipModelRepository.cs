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
    public class DocumentPlot_DocumentOwnerRelashionshipModelRepository : IDocumentPlot_DocumentOwnerRelashionshipModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public DocumentPlot_DocumentOwnerRelashionshipModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task AddRelashionship(DocumentPlot_DocumentOwnerRelashionship relashionship) {
            var existingRelashionship = await _WolfDbContext.documentPlot_DocumentOwenerRelashionships
                .FirstOrDefaultAsync(r => r.DocumentPlotId == relashionship.DocumentPlotId && r.DocumentOwnerID == relashionship.DocumentOwnerID);

            if (existingRelashionship != null)
            {
                // Update the input relationship with existing values if they are not null or empty
                relashionship.DocumentPlotId = existingRelashionship.DocumentPlotId != 0 ? existingRelashionship.DocumentPlotId : relashionship.DocumentPlotId;
                relashionship.DocumentPlot = existingRelashionship.DocumentPlot ?? relashionship.DocumentPlot;
                relashionship.DocumentOwnerID = existingRelashionship.DocumentOwnerID != 0 ? existingRelashionship.DocumentOwnerID : relashionship.DocumentOwnerID;
                relashionship.DocumentOwner = existingRelashionship.DocumentOwner ?? relashionship.DocumentOwner;
                relashionship.IdealParts = existingRelashionship.IdealParts != 0 ? existingRelashionship.IdealParts : relashionship.IdealParts;
                relashionship.WayOfAcquiring = !string.IsNullOrEmpty(existingRelashionship.WayOfAcquiring) ? existingRelashionship.WayOfAcquiring : relashionship.WayOfAcquiring;
            }
            else
            {
                // Add the new relationship
                await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.AddAsync(relashionship);
                await _WolfDbContext.SaveChangesAsync();
            }
        }

        public async Task<DocumentPlot_DocumentOwnerRelashionship> FindById(int id) {
            return await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.FindAsync(id);
        }
    }
}
