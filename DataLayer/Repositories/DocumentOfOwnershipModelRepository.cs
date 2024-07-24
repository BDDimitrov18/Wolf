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

        public async Task<bool> EditDocument(DocumentOfOwnership document)
        {
            // Find the existing document in the database
            var existingDocument = await _WolfDbContext.DocumentsOfOwnership
                .FirstOrDefaultAsync(d => d.DocumentId == document.DocumentId);

            // If the document is found, update its properties
            if (existingDocument != null)
            {
                existingDocument.TypeOfDocument = document.TypeOfDocument;
                existingDocument.NumberOfDocument = document.NumberOfDocument;
                existingDocument.Issuer = document.Issuer;
                existingDocument.TOM = document.TOM;
                existingDocument.register = document.register;
                existingDocument.DocCase = document.DocCase;
                existingDocument.TypeOfOwnership = document.TypeOfOwnership;
                existingDocument.DateOfIssuing = document.DateOfIssuing;
                existingDocument.DateOfRegistering = document.DateOfRegistering;

                // Save changes to the database
                await _WolfDbContext.SaveChangesAsync();
                return true;
            }

            // Return false if the document was not found
            return false;
        }
    }
}
