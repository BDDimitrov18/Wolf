using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRequestModelRepository
    {
        public void Add(List<Request> requests);
        public IEnumerable<Request> GetAll();

        public Task<bool> Delete(List<Request> requests);
    }
}
