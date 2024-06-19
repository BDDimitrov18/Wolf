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
        public Client Add(Client client);

        public IEnumerable<Client> GetAll();
    }
}
