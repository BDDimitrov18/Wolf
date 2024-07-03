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

        public async Task AddRelashionship(DocumentOfOwnership_OwnerRelashionship relashionship) {
            var existingRelashionship = await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships
                .FirstOrDefaultAsync(r => r.DocumentID == relashionship.DocumentID && r.OwnerID == relashionship.OwnerID);

            if (existingRelashionship != null)
            {
                // Update the input relationship with existing values if they are not null or empty
                relashionship.DocumentOwnerID = existingRelashionship.DocumentOwnerID;
                relashionship.DocumentID = existingRelashionship.DocumentID != 0 ? existingRelashionship.DocumentID : relashionship.DocumentID;
                relashionship.Document = existingRelashionship.Document ?? relashionship.Document;
                relashionship.OwnerID = existingRelashionship.OwnerID != 0 ? existingRelashionship.OwnerID : relashionship.OwnerID;
                relashionship.Owner = existingRelashionship.Owner ?? relashionship.Owner;
            }
            else
            {
                // Add the new relationship
                await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships.AddAsync(relashionship);
                await _WolfDbContext.SaveChangesAsync();
            }
        }

        public async Task<DocumentOfOwnership_OwnerRelashionship> FindById(int id) {
            return await _WolfDbContext.DocumentOfOwnership_OwnerRelashionships.FindAsync(id);
        }
    }
}
