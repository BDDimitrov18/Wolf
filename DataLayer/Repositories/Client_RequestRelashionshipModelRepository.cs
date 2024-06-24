using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Client_RequestRelashionshipModelRepository : IClient_RequestRelashionshipModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public Client_RequestRelashionshipModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public List<Client_RequestRelashionship> Add(Request request, List<Client> clients) {
            List<Client_RequestRelashionship> client_RequestRelashionships = new List<Client_RequestRelashionship>();
            foreach (var client in clients)
            {
                Client_RequestRelashionship client_RequestRelashionship = new Client_RequestRelashionship() { 
                    RequestId = request.RequestId,
                    ClientId = client.ClientId,
                };
                _WolfDbContext.Client_RequestRelashionships.Add(client_RequestRelashionship);
                client_RequestRelashionships.Add(client_RequestRelashionship);
            }
            _WolfDbContext.SaveChanges();
            return client_RequestRelashionships;
        }
    }
}
