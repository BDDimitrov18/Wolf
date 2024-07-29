using DataAccessLayer.Migrations;
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
    public class PowerOfAttorneyModelRepository : IPowerOfAttorneyModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public PowerOfAttorneyModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }
        public async Task CreatePowerOfAttorney(PowerOfAttorneyDocument powerOfAttorney)
        {
            var existingDocument = await _WolfDbContext.powerOfAttorneyDocuments
                .FirstOrDefaultAsync(d => d.number == powerOfAttorney.number);

            if (existingDocument != null)
            {
                // Compare all relevant fields to check for differences
                bool isDifferent = existingDocument.dateOfIssuing != powerOfAttorney.dateOfIssuing ||
                                   existingDocument.Issuer != powerOfAttorney.Issuer;

                if (!isDifferent)
                {
                    // Copy necessary fields from existing document to the input document
                    powerOfAttorney.PowerOfAttorneyId = existingDocument.PowerOfAttorneyId;
                    powerOfAttorney.RowVersion = existingDocument.RowVersion;
                    return;
                }
            }

            // Add the new document
            _WolfDbContext.powerOfAttorneyDocuments.Add(powerOfAttorney);
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<bool> EditPowerOfAttorney(PowerOfAttorneyDocument powerOfAttorneyDocument)
        {
            // Find the existing PowerOfAttorneyDocument in the database
            var existingDocument =await  _WolfDbContext.powerOfAttorneyDocuments
                .FirstOrDefaultAsync(d => d.PowerOfAttorneyId == powerOfAttorneyDocument.PowerOfAttorneyId);

            // If the document is found, update its properties
            if (existingDocument != null)
            {
                existingDocument.number = powerOfAttorneyDocument.number;
                existingDocument.dateOfIssuing = powerOfAttorneyDocument.dateOfIssuing;
                existingDocument.Issuer = powerOfAttorneyDocument.Issuer;

                // Save changes to the database
                await _WolfDbContext.SaveChangesAsync();
                return true;
            }

            // Return false if the document was not found
            return false;
        }
    }
}
