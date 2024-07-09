using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IActivity_PlotRelashionshipModelRepository
    {
        public Task Add(Activity_PlotRelashionship relashionship);
        public Task<bool> OnActivityDeleteAsync(Activity activity);
    }
}
