using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> OnRequestDeleteAsync(Request request, List<Client_RequestRelashionship> client_RequestRelashionships)
        {
            try
            {
                // Find the Client_RequestRelashionships that have the same RequestId as the provided request
                var clientRequestsToDelete = await _WolfDbContext.Client_RequestRelashionships
                    .Where(cr => cr.RequestId == request.RequestId)
                    .ToListAsync();

                if (clientRequestsToDelete.Any())
                {
                    client_RequestRelashionships = new List<Client_RequestRelashionship>(clientRequestsToDelete);
                    _WolfDbContext.Client_RequestRelashionships.RemoveRange(clientRequestsToDelete);
                    var affectedRows = await _WolfDbContext.SaveChangesAsync();

                    // Check if any rows were affected
                    return affectedRows > 0;
                }

                // If no client requests were found to delete, return true (indicating no work to do)
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging framework)
                // Example: _logger.LogError(ex, "An error occurred while deleting client requests");

                // Return false to indicate failure
                return false;
            }
        }

        public async Task<bool> OnDeleteClients(List<Client> clients)
        {
            // Check if the list of clients is null or empty
            if (clients == null || clients.Count == 0)
            {
                return false;
            }

            try
            {
                // Extract client IDs from the provided clients list
                var clientIds = clients.Select(c => c.ClientId).ToList();

                // Find all Client_RequestRelashionship entries with matching client IDs
                var clientRelationships = _WolfDbContext.Client_RequestRelashionships
                    .Where(cr => clientIds.Contains(cr.ClientId))
                    .ToList();

                // Remove the found relationships
                _WolfDbContext.Client_RequestRelashionships.RemoveRange(clientRelationships);

                // Save changes to the database asynchronously
                await _WolfDbContext.SaveChangesAsync();

                return true; // Indicate that the operation was successful
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                // Handle the exception as needed

                return false; // Indicate that the operation failed
            }
        }
    }
}
