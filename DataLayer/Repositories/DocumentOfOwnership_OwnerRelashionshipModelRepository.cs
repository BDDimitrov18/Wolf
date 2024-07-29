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
    public class DocumentOfOwnership_OwnerRelashionshipModelRepository : IDocumentOfOwnership_OwnerRelashionshipModelRepository 
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public DocumentOfOwnership_OwnerRelashionshipModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task AddRelashionship(DocumentOfOwnership_OwnerRelashionship relashionship)
        {
            var existingRelashionship = await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships
                .FirstOrDefaultAsync(r => r.DocumentID == relashionship.DocumentID && r.OwnerID == relashionship.OwnerID);

            if (existingRelashionship != null)
            {
                // Compare all relevant fields to check for differences
                bool isDifferent = existingRelashionship.DocumentID != relashionship.DocumentID ||
                                   existingRelashionship.OwnerID != relashionship.OwnerID;

                if (!isDifferent)
                {
                    // Copy necessary fields from existing relationship to the input relationship
                    relashionship.DocumentOwnerID = existingRelashionship.DocumentOwnerID;
                    relashionship.RowVersion = existingRelashionship.RowVersion;
                    relashionship.Document = existingRelashionship.Document;
                    relashionship.Owner = existingRelashionship.Owner;
                    return;
                }
            }

            // Add the new relationship
            await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships.AddAsync(relashionship);
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<DocumentOfOwnership_OwnerRelashionship> FindById(int id) {
            return await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships.FindAsync(id);
        }
        public async Task<bool> onPlotOwnerDelete(int id)
        {
            try
            {
                int br = _WolfDbContext.documentPlot_DocumentOwenerRelashionships.Where(opt => opt.DocumentOwnerID == id).Count();

                if (br == 0) {
                    _WolfDbContext.DocumentOfOwnership_OwnerRelashionships.Remove(await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships.FindAsync(id));
                    await _WolfDbContext.SaveChangesAsync(); 
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> getIdOnPlotOwner(DocumentPlot_DocumentOwnerRelashionship relashionship) {
            var result = await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.FindAsync(relashionship.Id);
            if (result != null) { 
                return result.DocumentOwnerID;
            }
            return -1;
        }
    }
}
