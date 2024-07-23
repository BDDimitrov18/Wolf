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
    public class RequestModelRepository : IRequestModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public RequestModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public void Add(List<Request> requests)
        {
            foreach (var request in requests)
            {
                _WolfDbContext.Requests.Add(request);
                _WolfDbContext.SaveChanges();
            }
        }

        public bool Edit(Request request)
        {
            var existingRequest = _WolfDbContext.Requests.FirstOrDefault(r => r.RequestId == request.RequestId);

            if (existingRequest != null)
            {
                // Update only the necessary fields
                existingRequest.RequestName = request.RequestName;
                existingRequest.Price = request.Price;
                existingRequest.PaymentStatus = request.PaymentStatus;
                existingRequest.Advance = request.Advance;
                existingRequest.Comments = request.Comments;

                // Save changes to the database
                _WolfDbContext.SaveChanges();
                return true; // Indicate the operation was successful
            }

            return false; // Indicate the operation failed
        }

        public IEnumerable<Request> GetAll()
        {
            return _WolfDbContext.Requests.ToList();
        }

        public async Task<bool> Delete(List<Request> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    var entity = await _WolfDbContext.Requests.FindAsync(request.RequestId);
                    if (entity != null)
                    {
                        _WolfDbContext.Requests.Remove(entity);
                    }
                }

                // Save changes to the database
                var affectedRows = await _WolfDbContext.SaveChangesAsync();

                // Check if any rows were affected
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging framework)
                // Example: _logger.LogError(ex, "An error occurred while deleting requests");

                // Optionally, you can throw a custom exception or return false to indicate failure
                return false;
            }
        }

    }
}
