using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public List<Client> Add(List<Client> clients) {
            foreach (var client in clients)
            {
                _WolfDbContext.Clients.Add(client);
            }
            _WolfDbContext.SaveChanges();
            return clients;
        }

        public IEnumerable<Client> GetAll()
        {
            return _WolfDbContext.Clients.ToList();
        }

        public List<Client> GetLinked(Request request) {
            var linkedClients = (from cr in _WolfDbContext.Client_RequestRelashionships
                                 join c in _WolfDbContext.Clients on cr.ClientId equals c.ClientId
                                 where cr.RequestId == request.RequestId
                                 select c).ToList();

            return linkedClients;
        }

        public async Task<bool> Edit(Client client)
        {
            var existingClient = _WolfDbContext.Clients.FirstOrDefault(c => c.ClientId == client.ClientId);

            if (existingClient != null)
            {
                // Update only the necessary fields
                existingClient.FirstName = client.FirstName;
                existingClient.MiddleName = client.MiddleName;
                existingClient.LastName = client.LastName;
                existingClient.Phone = client.Phone;
                existingClient.Email = client.Email;
                existingClient.Address = client.Address;
                existingClient.ClientLegalType = client.ClientLegalType;

                try
                {
                    // Save changes to the database
                    await _WolfDbContext.SaveChangesAsync();
                    return true; // Indicate that the operation was successful
                }
                catch (Exception ex)
                {
                    // Log the exception (logging not shown here)
                    // Handle the exception as needed
                    Console.WriteLine($"Exception: {ex.Message}");
                    return false; // Indicate that the operation failed
                }
            }
            else
            {
                // Log that the client was not found (logging not shown here)
                return false; // Indicate that the operation failed
            }
        }
    }
}

