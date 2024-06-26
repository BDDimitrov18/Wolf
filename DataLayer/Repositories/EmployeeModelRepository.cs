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
    }
}
