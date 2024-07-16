using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPlot_DocumentOfOwnershipRelashionshipModelRepository
    {
        public Task AddRelashionship(Plot_DocumentOfOwnershipRelashionship relashionship);
        public Task<Plot_DocumentOfOwnershipRelashionship> FindById(int id);
        public Task<bool> onPlotOwnerDelete(int id);
        public Task<int> getIdOnPlotOwner(DocumentPlot_DocumentOwnerRelashionship relashionship);
    }
}
