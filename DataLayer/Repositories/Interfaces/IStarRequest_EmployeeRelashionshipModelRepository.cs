using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IStarRequest_EmployeeRelashionshipModelRepository
    {
        public Task AddAsync(starRequest_EmployeeRelashionship relationship);
        public Task<bool> DeleteAsync(starRequest_EmployeeRelashionship relationship);
        public Task<List<starRequest_EmployeeRelashionship>> GetByEmployeeID(int employeeId);
    }
}
