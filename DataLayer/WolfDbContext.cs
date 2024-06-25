using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class WolfDbContext : IdentityDbContext<IdentityUser>
    {
        public WolfDbContext(DbContextOptions<WolfDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<WorkTask> Tasks  { get; set; }

        public DbSet<Request> Requests  { get; set; }

        public DbSet<Plot> Plots { get; set; }

        public DbSet<Invoice> Invoices  { get; set; }

        public DbSet<Client_RequestRelashionship> Client_RequestRelashionships { get; set; }

        public DbSet<Request_PlotRelashionship> Request_PlotRelashionships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

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

            #region InvoiceConfig
            modelBuilder.Entity<Invoice>()
              .HasOne(inv => inv.Request)
              .WithMany(r => r.Invoices)
              .HasForeignKey(inv => inv.RequestId);
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


            #endregion

            #region Request_PlotRelashionShip
            modelBuilder.Entity<Request_PlotRelashionship>()
             .HasKey(rp => new { rp.requestId, rp.plotId });

            modelBuilder.Entity<Request_PlotRelashionship>()
                .HasOne(rp => rp.Request)
                .WithMany(r => r.request_PlotRelashionships)
                .HasForeignKey(rp => rp.requestId);

            modelBuilder.Entity<Request_PlotRelashionship>()
                .HasOne(rp => rp.plot)
                .WithMany(p => p.request_PlotRelashionships)
                .HasForeignKey(rp => rp.plotId);

            #endregion

            #region 
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "admin",
                    NormalizedName = "Admin",
                    ConcurrencyStamp = "1"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "user",
                    NormalizedName = "User",
                    ConcurrencyStamp = "2"
                }
            );
            #endregion
        }
    }
}
