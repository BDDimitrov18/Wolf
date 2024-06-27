using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IClientModelRepository
    {
        public List<Client> Add(List<Client> client);

        public IEnumerable<Client> GetAll();
        public List<Client> GetLinked(Request request);

        
    }
}
