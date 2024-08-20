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
    public class OwnerModelRepository : IOwnerModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public OwnerModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task AddOwner(Owner owner)
        {
            // Check if an owner with the same EGN already exists
            var existingOwnerWithSameEgn = await _WolfDbContext.Owners
                .FirstOrDefaultAsync(o => o.EGN == owner.EGN);

            if (existingOwnerWithSameEgn != null)
            {
                // Compare all relevant fields to check for differences
                bool isDifferent = existingOwnerWithSameEgn.FullName != owner.FullName ||
                                   existingOwnerWithSameEgn.EGN != owner.EGN ||
                                   existingOwnerWithSameEgn.Address != owner.Address;

                if (isDifferent)
                {
                    // Update existing entity with the new values
                    existingOwnerWithSameEgn.FullName = owner.FullName;
                    existingOwnerWithSameEgn.Address = owner.Address;

                    _WolfDbContext.Owners.Update(existingOwnerWithSameEgn);
                    await _WolfDbContext.SaveChangesAsync();
                }

                // Set the OwnerID of the input owner to the existing one
                owner.OwnerID = existingOwnerWithSameEgn.OwnerID;
                return;
            }

            // Add the new owner
            _WolfDbContext.Owners.Add(owner);
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<Owner> FindById(int id)
        {
            return await _WolfDbContext.Owners.FindAsync(id);
        }

        public async Task<bool> EditOwner(Owner owner)
        {
            var existingOwner = await _WolfDbContext.Owners.FindAsync(owner.OwnerID);

            if (existingOwner == null)
            {
                return false; // Owner not found
            }

            // Update only the necessary fields
            existingOwner.FullName= owner.FullName;
            existingOwner.EGN = owner.EGN;
            existingOwner.Address = owner.Address;

            try
            {
                await _WolfDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(owner.OwnerID))
                {
                    return false; // Owner no longer exists
                }
                else
                {
                    throw; // Concurrency issue
                }
            }
            catch (Exception)
            {
                return false; // Some other exception occurred
            }
        }

        private bool OwnerExists(int id)
        {
            return _WolfDbContext.Owners.Any(e => e.OwnerID == id);
        }

        public async Task<List<Owner>> getAllOwners() { 
            return await _WolfDbContext.Owners.ToListAsync();
        }
    }
}
