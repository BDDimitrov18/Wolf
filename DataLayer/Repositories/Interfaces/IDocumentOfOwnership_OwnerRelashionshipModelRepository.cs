using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDocumentOfOwnership_OwnerRelashionshipModelRepository
    {
        public Task AddRelashionship(DocumentOfOwnership_OwnerRelashionship relashionship);
        public Task<DocumentOfOwnership_OwnerRelashionship> FindById(int id);

        public Task<bool> onPlotOwnerDelete(int id);

        public Task<int> getIdOnPlotOwner(DocumentPlot_DocumentOwnerRelashionship relashionship);
    }
}
