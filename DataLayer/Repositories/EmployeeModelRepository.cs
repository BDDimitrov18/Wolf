using DataAccessLayer.Interfaces;
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
        public WolfDbContext _WolfDbContext { get; set; }

        public EmployeeModelRepository(IWolfDbContext wolfDbContext)
        {
            this._WolfDbContext = wolfDbContext as WolfDbContext;
        }

        public void Add(Employee employee)
        {
            _WolfDbContext.Employees.Add(employee);
            _WolfDbContext.SaveChanges();
        }
    }
}
