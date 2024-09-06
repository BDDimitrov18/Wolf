using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmployeeModelRepository : IEmployeeModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public EmployeeModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public List<Employee> Add(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                _WolfDbContext.Employees.Add(employee);
            }
            _WolfDbContext.SaveChanges();
            return employees;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _WolfDbContext.Employees.ToList();
        }

        public async Task<Employee> Get(int id) {
            return await _WolfDbContext.Employees.FindAsync(id);
        }

        public async Task<bool> EditEmployee(Employee employee)
        {
            var existingEmployee = await _WolfDbContext.Employees.FindAsync(employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.Email = employee.Email;
                existingEmployee.SecondName = employee.SecondName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.phone = employee.phone;
                existingEmployee.Outsider = employee.Outsider;
                
                _WolfDbContext.Employees.Update(existingEmployee);
                await _WolfDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
