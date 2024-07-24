using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDocumentOfOwnershipModelRepository
    {
        public Task AddDocument(DocumentOfOwnership document);
        public Task<DocumentOfOwnership> FindById(int id);
        public Task<bool> EditDocument(DocumentOfOwnership document);
    }
}
