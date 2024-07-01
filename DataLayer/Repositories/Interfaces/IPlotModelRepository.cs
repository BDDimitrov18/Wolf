using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPlotModelRepository
    {
        public Task Add(Plot plot);
        public Task<List<Plot>> GetLinkedPlotsToActivty(int activityId);
    }
}
