using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IWolfDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkObject> WorkObjects { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<WorkTask> Tasks { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Plot> Plots { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Client_RequestRelashionship> Client_RequestRelashionships { get; set; }

        public DbSet<Employee_WorkObjectRelashionship> Employee_WorkObjectRelashionships { get; set; }

        public DbSet<WorkObject_PlotRelashionship> Object_PlotRelashionships { get; set; }

        public DbSet<Request_WorkObjectRelashionship> Request_WorkObjectRelashionships { get; set; }
    }
}
