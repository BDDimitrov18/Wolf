﻿using DataAccessLayer.Models;
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

            var existingRelashionship = await _WolfDbContext.documentPlot_DocumentOwenerRelashionships
                .Include(r => r.DocumentPlot)
                    .ThenInclude(dp => dp.Plot)
                .Include(r => r.DocumentPlot)
                    .ThenInclude(dp => dp.documentOfOwnership)
                        .ThenInclude(documentOfOwnership => documentOfOwnership.DocumentOwners)
                            .ThenInclude(ownerRel => ownerRel.Owner)
                .Include(r => r.DocumentOwner)
                    .ThenInclude(ownerRel => ownerRel.Document)
                .Include(r => r.DocumentOwner)
                    .ThenInclude(ownerRel => ownerRel.Owner)
                .FirstOrDefaultAsync(r => r.DocumentPlotId == relashionship.DocumentPlotId && r.DocumentOwnerID == relashionship.DocumentOwnerID);

            if (existingRelashionship != null)
            {
                // Update the existing relationship with input values
                existingRelashionship.IdealParts = relashionship.IdealParts != 0 ? relashionship.IdealParts : existingRelashionship.IdealParts;
                existingRelashionship.WayOfAcquiring = !string.IsNullOrEmpty(relashionship.WayOfAcquiring) ? relashionship.WayOfAcquiring : existingRelashionship.WayOfAcquiring;

                _WolfDbContext.Entry(existingRelashionship).State = EntityState.Modified;
            }
            else
            {
                await _WolfDbContext.documentPlot_DocumentOwenerRelashionships.AddAsync(relashionship);
            }

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
                .Where(dp => plotIds.Contains(dp.DocumentPlot.PlotId))
                .ToList();

            return result;
        }
    }
}