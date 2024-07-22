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

        public List<Client_RequestRelashionship> Add(Request request, List<Client> clients)
        {
            List<Client_RequestRelashionship> client_RequestRelashionships = new List<Client_RequestRelashionship>();
            var newClientRelationships = new List<Client_RequestRelashionship>();

            foreach (var client in clients)
            {
                Client_RequestRelashionship client_RequestRelashionship = new Client_RequestRelashionship
                {
                    RequestId = request.RequestId,
                    ClientId = client.ClientId,
                    Request = null, // We do not need to set the full Request object here
                    Client = null // We do not need to set the full Client object here
                };

                _WolfDbContext.Client_RequestRelashionships.Add(client_RequestRelashionship);
                newClientRelationships.Add(client_RequestRelashionship);
            }

            _WolfDbContext.SaveChanges();

            // Materialize the new client relationships into a list in memory
            var newClientRelationshipsList = newClientRelationships.ToList();

            // Load the full client data in the newly created relationships
            foreach (var relationship in newClientRelationshipsList)
            {
                relationship.Client = _WolfDbContext.Clients.Find(relationship.ClientId);
                relationship.Request = _WolfDbContext.Requests.Find(relationship.RequestId);
            }

            return newClientRelationshipsList;
        }






        public async Task<bool> OnRequestDeleteAsync(Request request)
        {
            try
            {
                // Find the Client_RequestRelashionships that have the same RequestId as the provided request
                var clientRequestsToDelete = await _WolfDbContext.Client_RequestRelashionships
                    .Where(cr => cr.RequestId == request.RequestId)
                    .ToListAsync();

                if (clientRequestsToDelete.Any())
                {
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

        public async Task<bool> OnDeleteClients(List<Client_RequestRelashionship> clients)
        {
            // Check if the list of clients is null or empty
            if (clients == null || clients.Count == 0)
            {
                return false;
            }

            try
            {
                // Load all relationships into memory and then filter
                var allClientRelationships = await _WolfDbContext.Client_RequestRelashionships.ToListAsync();

                var clientsToDelete = allClientRelationships
                    .Where(cr => clients.Any(c => c.ClientId == cr.ClientId && c.RequestId == cr.RequestId))
                    .ToList();

                if (clientsToDelete.Count == 0)
                {
                    return false; // No matching relationships found
                }

                // Remove the found relationships
                _WolfDbContext.Client_RequestRelashionships.RemoveRange(clientsToDelete);

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
