using DataAccessLayer.Migrations;
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
    public class StarRequest_EmployeeModelRepository : IStarRequest_EmployeeRelashionshipModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public StarRequest_EmployeeModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task AddAsync(starRequest_EmployeeRelashionship relationship)
        {
            if (relationship == null)
            {
                throw new ArgumentNullException(nameof(relationship));
            }

            // Optionally check if the relationship already exists
            var existingRelationship = await _WolfDbContext.starRequest_EmployeeRelashionships
                .FirstOrDefaultAsync(r => r.RequestId == relationship.RequestId && r.EmployeeID == relationship.EmployeeID);

            if (existingRelationship != null)
            {
                throw new InvalidOperationException("The relationship already exists.");
            }

            // Add the new relationship
            await _WolfDbContext.starRequest_EmployeeRelashionships.AddAsync(relationship);

            // Save changes to the database
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(starRequest_EmployeeRelashionship relationship)
        {
            if (relationship == null)
            {
                throw new ArgumentNullException(nameof(relationship));
            }

            // Find the existing relationship
            var existingRelationship = await _WolfDbContext.starRequest_EmployeeRelashionships
                .FirstOrDefaultAsync(r => r.RequestId == relationship.RequestId && r.EmployeeID == relationship.EmployeeID);

            if (existingRelationship == null)
            {
                return false; // Relationship not found
            }

            // Remove the relationship
            _WolfDbContext.starRequest_EmployeeRelashionships.Remove(existingRelationship);

            // Save changes to the database
            await _WolfDbContext.SaveChangesAsync();

            return true; // Successfully deleted
        }

        public async Task<List<starRequest_EmployeeRelashionship>> GetByEmployeeID(int employeeId)
        {
            // Query the database for all relationships matching the given employee ID
            return await _WolfDbContext.starRequest_EmployeeRelashionships
                .Where(r => r.EmployeeID == employeeId)
                .ToListAsync();
        }
    }
}
