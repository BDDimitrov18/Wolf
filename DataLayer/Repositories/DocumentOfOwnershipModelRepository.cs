using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DocumentOfOwnershipModelRepository : IDocumentOfOwnershipModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public DocumentOfOwnershipModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task AddDocument(DocumentOfOwnership document) {
            var existingDocument = _WolfDbContext.DocumentsOfOwnership
                .FirstOrDefault(d => d.NumberOfDocument == document.NumberOfDocument);

            if (existingDocument != null)
            {
                // Update the input document with existing values if they are not null or empty
                document.DocumentId = existingDocument.DocumentId;
                document.TypeOfDocument = !string.IsNullOrEmpty(existingDocument.TypeOfDocument) ? existingDocument.TypeOfDocument : document.TypeOfDocument;
                document.Issuer = !string.IsNullOrEmpty(existingDocument.Issuer) ? existingDocument.Issuer : document.Issuer;
                document.TOM = existingDocument.TOM != 0 ? existingDocument.TOM : document.TOM;
                document.register = !string.IsNullOrEmpty(existingDocument.register) ? existingDocument.register : document.register;
                document.DocCase = !string.IsNullOrEmpty(existingDocument.DocCase) ? existingDocument.DocCase : document.DocCase;
                document.DateOfIssuing = existingDocument.DateOfIssuing != DateTime.MinValue ? existingDocument.DateOfIssuing : document.DateOfIssuing;
                document.DateOfRegistering = existingDocument.DateOfRegistering != DateTime.MinValue ? existingDocument.DateOfRegistering : document.DateOfRegistering;
            }
            else
            {
                // Add the new document
                _WolfDbContext.DocumentsOfOwnership.Add(document);
                await _WolfDbContext.SaveChangesAsync();
            }
        }

        public async Task<DocumentOfOwnership> FindById(int id) {
            return await _WolfDbContext.DocumentsOfOwnership.FindAsync(id);
        }
    }
}
