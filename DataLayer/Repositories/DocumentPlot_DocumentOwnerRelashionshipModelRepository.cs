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

        public async Task AddRelashionship(DocumentPlot_DocumentOwnerRelashionship relashionship)
        {
            if (relashionship == null)
                throw new ArgumentNullException(nameof(relashionship));

            // Load the DocumentPlot entity if it is not already loaded
            if (relashionship.DocumentPlot == null && relashionship.DocumentPlotId != 0)
            {
                relashionship.DocumentPlot = await _WolfDbContext.Plot_DocumentOfOwnerships
                    .Include(dp => dp.Plot)
                    .Include(dp => dp.documentOfOwnership)
                    .FirstOrDefaultAsync(dp => dp.DocumentPlotId == relashionship.DocumentPlotId);

                if (relashionship.DocumentPlot == null)
                    throw new ArgumentException("Invalid DocumentPlotId");
            }

            // Load the DocumentOwner entity if it is not already loaded
            if (relashionship.DocumentOwner == null && relashionship.DocumentOwnerID != 0)
            {
                relashionship.DocumentOwner = await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships
                    .Include(ownerRel => ownerRel.Document)
                    .Include(ownerRel => ownerRel.Owner)
                    .FirstOrDefaultAsync(ownerRel => ownerRel.DocumentOwnerID == relashionship.DocumentOwnerID);

                if (relashionship.DocumentOwner == null)
                    throw new ArgumentException("Invalid DocumentOwnerID");
            }

            // Load the PowerOfAttorneyDocument entity if it is not already loaded
            if (relashionship.powerOfAttorneyDocument == null && relashionship.PowerOfAttorneyId != 0)
            {
                relashionship.powerOfAttorneyDocument = await _WolfDbContext.powerOfAttorneyDocuments
                    .FirstOrDefaultAsync(poa => poa.PowerOfAttorneyId == relashionship.PowerOfAttorneyId);

                if (relashionship.powerOfAttorneyDocument == null)
                    throw new ArgumentException("Invalid PowerOfAttorneyId");
            }

            
            await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.AddAsync(relashionship);

            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<DocumentPlot_DocumentOwnerRelashionship> FindById(int id) {
            return await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.FindAsync(id);
        }

        public List<DocumentPlot_DocumentOwnerRelashionship> GetLinked(List<Plot> plots)
        {
            var plotIds = plots.Select(p => p.PlotId).ToList();

            var result = _WolfDbContext.documentPlot_DocumentOwenerRelashionships
                .Include(dp => dp.DocumentPlot)
                    .ThenInclude(dpr => dpr.Plot)
                .Include(dp => dp.DocumentPlot)
                    .ThenInclude(dpr => dpr.documentOfOwnership)
                        .ThenInclude(documentOfOwnership => documentOfOwnership.DocumentOwners)
                            .ThenInclude(dor => dor.Owner)
                .Include(dp => dp.DocumentOwner)
                    .ThenInclude(documentOwner => documentOwner.Document)
                .Include(dp => dp.DocumentOwner)
                    .ThenInclude(documentOwner => documentOwner.Owner)
                .Include(dp => dp.powerOfAttorneyDocument) // Include PowerOfAttorneyDocument
                .Where(dp => plotIds.Contains(dp.DocumentPlot.PlotId))
                .ToList();

            return result;
        }

        public async Task<bool> deleteRelashionship(DocumentPlot_DocumentOwnerRelashionship relashionship, DocumentPlot_DocumentOwnerRelashionship plotOwner)
        {
            try {
               var result = await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.FindAsync(relashionship.Id);
                if (result == null) {
                    return false;
                }
                plotOwner = new DocumentPlot_DocumentOwnerRelashionship();
                plotOwner = result;
                _WolfDbContext.documentPlot_DocumentOwenerRelashionships.Remove(result);
                await _WolfDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public async Task<bool> EditRelashionship(DocumentPlot_DocumentOwnerRelashionship relashionship)
        {
            var existingRelashionship = await _WolfDbContext.documentPlot_DocumentOwenerRelashionships
                .FirstOrDefaultAsync(r => r.Id == relashionship.Id);

            if (existingRelashionship != null)
            {
                // Update only the specified fields
                existingRelashionship.IdealParts = relashionship.IdealParts;
                existingRelashionship.WayOfAcquiring = relashionship.WayOfAcquiring;
                existingRelashionship.isDrob = relashionship.isDrob;

                // Save changes to the database
                await _WolfDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
