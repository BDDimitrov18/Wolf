using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ClientModelRepository : IClientModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public ClientModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public Client Add(Client client) {

            _WolfDbContext.Clients.Add(client);
            _WolfDbContext.SaveChanges();
            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            return _WolfDbContext.Clients.ToList();
        }
    }
}
