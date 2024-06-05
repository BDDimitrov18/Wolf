using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class WolfDbContext : DbContext
    {
        public WolfDbContext(DbContextOptions<WolfDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkObject> WorkObjects { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<WorkTask> Tasks  { get; set; }

        public DbSet<Request> Requests  { get; set; }

        public DbSet<Plot> Plots { get; set; }

        public DbSet<Invoice> Invoices  { get; set; }

        public DbSet<Client_RequestRelashionship> Client_RequestRelashionships { get; set; }

        public DbSet<Employee_WorkObjectRelashionship> Employee_WorkObjectRelashionships  { get; set; }

        public DbSet<WorkObject_PlotRelashionship> Object_PlotRelashionships  { get; set; }

        public DbSet<Request_WorkObjectRelashionship> Request_WorkObjectRelashionships  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            #region WorkTaskRelashionshipConfig         
            modelBuilder.Entity<WorkTask>()
                .HasOne(wt => wt.Activity)
                .WithMany() 
                .HasForeignKey(wt => wt.ActivityId);

            
            modelBuilder.Entity<WorkTask>()
                .HasOne(wt => wt.Executant)
                .WithMany() 
                .HasForeignKey(wt => wt.ExecutantId);

            
            modelBuilder.Entity<WorkTask>()
                .HasOne(wt => wt.Control)
                .WithMany() 
                .HasForeignKey(wt => wt.ControlId);
            #endregion

            #region WorkObject_PlotRelashionshipConfig
            modelBuilder.Entity<WorkObject_PlotRelashionship>()
        .HasKey(wopr => new { wopr.WorkObjectId, wopr.PlotId });

            modelBuilder.Entity<WorkObject_PlotRelashionship>()
                .HasOne(wopr => wopr.WorkObject)
                .WithMany(wo => wo.WorkObject_PlotRelationships)
                .HasForeignKey(wopr => wopr.WorkObjectId);

            modelBuilder.Entity<WorkObject_PlotRelashionship>()
                .HasOne(wopr => wopr.Plot)
                .WithMany(p => p.WorkObject_PlotRelationships)
                .HasForeignKey(wopr => wopr.PlotId);
            #endregion

            #region Request_WorkObjectRelashionshipConfig

            modelBuilder.Entity<Request_WorkObjectRelashionship>()
        .HasKey(rwor => new { rwor.RequestId, rwor.WorkObjectId });

            modelBuilder.Entity<Request_WorkObjectRelashionship>()
                .HasOne(rwor => rwor.Request)
                .WithMany(r => r.Request_WorkObjectRelationships)
                .HasForeignKey(rwor => rwor.RequestId);

            modelBuilder.Entity<Request_WorkObjectRelashionship>()
                .HasOne(rwor => rwor.WorkObject)
                .WithMany(w => w.Request_WorkObjectRelationships)
                .HasForeignKey(rwor => rwor.WorkObjectId);

            #endregion

            #region InvoiceConfig
            modelBuilder.Entity<Invoice>()
              .HasOne(inv => inv.Request)
              .WithMany(r => r.Invoices)
              .HasForeignKey(inv => inv.RequestId);
            #endregion

            #region Employee_WorkObjectRelashionshipConfig
            modelBuilder.Entity<Employee_WorkObjectRelashionship>()
        .HasKey(ewor => new { ewor.EmployeeId, ewor.WorkObjectId });

            modelBuilder.Entity<Employee_WorkObjectRelashionship>()
                .HasOne(ewor => ewor.Employee)
                .WithMany(e => e.Employee_WorkObjectRelationships)
                .HasForeignKey(ewor => ewor.EmployeeId);

            modelBuilder.Entity<Employee_WorkObjectRelashionship>()
                .HasOne(ewor => ewor.WorkObject)
                .WithMany(w => w.Employee_WorkObjectRelationships)
                .HasForeignKey(ewor => ewor.WorkObjectId);
            #endregion

            #region Client_RequestRelashionshipConfig
            modelBuilder.Entity<Client_RequestRelashionship>()
        .HasKey(crr => new { crr.RequestId, crr.ClientId });

            modelBuilder.Entity<Client_RequestRelashionship>()
                .HasOne(crr => crr.Request)
                .WithMany(r => r.Client_RequestRelationships)
                .HasForeignKey(crr => crr.RequestId);

            modelBuilder.Entity<Client_RequestRelashionship>()
                .HasOne(crr => crr.Client)
                .WithMany(c => c.Client_RequestRelationships)
                .HasForeignKey(crr => crr.ClientId);
            #endregion
            #region ActivityConfig
            modelBuilder.Entity<Activity>()
        .HasOne(a => a.Request)
        .WithMany(r => r.Activities)
        .HasForeignKey(a => a.RequestId);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.WorkObject)
                .WithMany(w => w.Activities)
                .HasForeignKey(a => a.WorkObjectId);
            #endregion
        }
    }
}
