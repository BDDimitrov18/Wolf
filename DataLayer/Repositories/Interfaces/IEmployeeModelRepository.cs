using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeeModelRepository
    {
        public List<Employee> Add(List<Employee> employees);

        public IEnumerable<Employee> GetAll();

        public Task<Employee> Get(int id);
        public Task<bool> EditEmployee(Employee employee);
    }
}
