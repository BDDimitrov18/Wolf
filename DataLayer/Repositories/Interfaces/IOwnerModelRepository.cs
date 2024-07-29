using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IOwnerModelRepository
    {
        public Task AddOwner(Owner owner);

        public Task<Owner> FindById(int id);
        public Task<bool> EditOwner(Owner owner);

        public Task<List<Owner>> getAllOwners();
    }
}
