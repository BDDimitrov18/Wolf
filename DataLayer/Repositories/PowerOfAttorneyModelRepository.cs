using DataAccessLayer.Migrations;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PowerOfAttorneyModelRepository : IPowerOfAttorneyModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public PowerOfAttorneyModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task CreatePowerOfAttorney(PowerOfAttorneyDocument powerOfattorney) {
            _WolfDbContext.powerOfAttorneyDocuments.Add(powerOfattorney);
            await _WolfDbContext.SaveChangesAsync();
        }
    }
}
