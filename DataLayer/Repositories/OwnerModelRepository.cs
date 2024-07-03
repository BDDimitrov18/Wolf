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

        public async Task AddOwner(Owner owner) {
            _WolfDbContext.Owners.Add(owner);
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<Owner> FindById(int id)
        {
            return await _WolfDbContext.Owners.FindAsync(id);
        }
    }
}
