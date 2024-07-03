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

        public DbSet<WorkTask> Tasks { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Plot> Plots { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Client_RequestRelashionship> Client_RequestRelashionships { get; set; }

        public DbSet<ActivityType> activityTypes { get; set; }

        public DbSet<TaskType> taskTypes { get; set; }

        public DbSet<Activity_PlotRelashionship> Activity_PlotRelashionships { get; set; }

        public DbSet<DocumentOfOwnership> DocumentsOfOwnership { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<DocumentOfOwnership_OwnerRelashionship> DocumentOfOwnership_OwnerRelashionships { get; set; }
        public DbSet<Plot_DocumentOfOwnershipRelashionship> Plot_DocumentOfOwnerships { get; set; }
        public DbSet<DocumentPlot_DocumentOwnerRelashionship> documentPlot_DocumentOwenerRelashionships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

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

            #region // Configure Activity
            // Configure Activity - Request relationship
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Request)
                .WithMany(r => r.Activities)
                .HasForeignKey(a => a.RequestId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure Activity - ActivityType relationship
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.ActivityType)
                .WithMany()
                .HasForeignKey(a => a.ActivityTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure ActivityType - TaskType relationship
            modelBuilder.Entity<ActivityType>()
                .HasMany(at => at.TaskTypes)
                .WithOne(tt => tt.Activity)
                .HasForeignKey(tt => tt.ActivityTypeID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Activity - WorkTask relationship
            modelBuilder.Entity<Activity>()
                .HasMany(a => a.Tasks)
                .WithOne(wt => wt.Activity)
                .HasForeignKey(wt => wt.ActivityId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure WorkTask - Executant relationship
            modelBuilder.Entity<WorkTask>()
                .HasOne(wt => wt.Executant)
                .WithMany()
                .HasForeignKey(wt => wt.ExecutantId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure WorkTask - Control relationship
            modelBuilder.Entity<WorkTask>()
                .HasOne(wt => wt.Control)
                .WithMany()
                .HasForeignKey(wt => wt.ControlId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure WorkTask - TaskType relationship
            modelBuilder.Entity<WorkTask>()
                .HasOne(wt => wt.taskType)
                .WithMany()
                .HasForeignKey(wt => wt.TaskTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure Activity - Plot relationship
            modelBuilder.Entity<Activity_PlotRelashionship>()
                 .HasKey(ap => new { ap.ActivityId, ap.PlotId });

            modelBuilder.Entity<Activity_PlotRelashionship>()
                .HasOne(ap => ap.Activity)
                .WithMany(a => a.ActivityPlots)
                .HasForeignKey(ap => ap.ActivityId);

            modelBuilder.Entity<Activity_PlotRelashionship>()
                .HasOne(ap => ap.Plot)
                .WithMany(p => p.ActivityPlots)
                .HasForeignKey(ap => ap.PlotId);



            #endregion

            #region documentsConfig
            modelBuilder.Entity<Plot>()
                .HasKey(p => p.PlotId);

            modelBuilder.Entity<Plot>()
                .HasMany(p => p.ActivityPlots)
                .WithOne(ap => ap.Plot)
                .HasForeignKey(ap => ap.PlotId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plot>()
                .HasMany(p => p.PlotDocuments)
                .WithOne(pd => pd.Plot)
                .HasForeignKey(pd => pd.PlotId)
                .OnDelete(DeleteBehavior.Cascade);

            // DocumentOfOwnership configuration
            modelBuilder.Entity<DocumentOfOwnership>()
                .HasKey(d => d.DocumentId);

            modelBuilder.Entity<DocumentOfOwnership>()
                .HasMany(d => d.DocumentOwners)
                .WithOne(docRel => docRel.Document)
                .HasForeignKey(docRel => docRel.DocumentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DocumentOfOwnership>()
                .HasMany(d => d.PlotsDocuments)
                .WithOne(pd => pd.documentOfOwnership)
                .HasForeignKey(pd => pd.DocumentOfOwnershipId)
                .OnDelete(DeleteBehavior.Cascade);

            // Owner configuration
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.OwnerID);

            modelBuilder.Entity<Owner>()
                .HasMany(o => o.documentOfOwnership_OwnerRelashionships)
                .WithOne(docRel => docRel.Owner)
                .HasForeignKey(docRel => docRel.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            // Plot_DocumentOfOwnershipRelashionship configuration
            modelBuilder.Entity<Plot_DocumentOfOwnershipRelashionship>()
                .HasKey(pd => pd.DocumentPlotId);

            modelBuilder.Entity<Plot_DocumentOfOwnershipRelashionship>()
                .HasOne(pd => pd.Plot)
                .WithMany(p => p.PlotDocuments)
                .HasForeignKey(pd => pd.PlotId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plot_DocumentOfOwnershipRelashionship>()
                .HasOne(pd => pd.documentOfOwnership)
                .WithMany(d => d.PlotsDocuments)
                .HasForeignKey(pd => pd.DocumentOfOwnershipId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid multiple cascade paths

            modelBuilder.Entity<Plot_DocumentOfOwnershipRelashionship>()
                .HasMany(pd => pd.documentPlot_DocumentOwnerRelashionships)
                .WithOne(dpo => dpo.DocumentPlot)
                .HasForeignKey(dpo => dpo.DocumentPlotId)
                .OnDelete(DeleteBehavior.Cascade);

            // DocumentOfOwnership_OwnerRelashionship configuration
            modelBuilder.Entity<DocumentOfOwnership_OwnerRelashionship>()
                .HasKey(docRel => docRel.DocumentOwnerID);

            modelBuilder.Entity<DocumentOfOwnership_OwnerRelashionship>()
                .HasOne(docRel => docRel.Document)
                .WithMany(d => d.DocumentOwners)
                .HasForeignKey(docRel => docRel.DocumentID)
                .OnDelete(DeleteBehavior.Restrict); // Avoid multiple cascade paths

            modelBuilder.Entity<DocumentOfOwnership_OwnerRelashionship>()
                .HasOne(docRel => docRel.Owner)
                .WithMany(o => o.documentOfOwnership_OwnerRelashionships)
                .HasForeignKey(docRel => docRel.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DocumentOfOwnership_OwnerRelashionship>()
                .HasMany(docRel => docRel.documentPlot_DocumentOwnerRelashionships)
                .WithOne(dpo => dpo.DocumentOwner)
                .HasForeignKey(dpo => dpo.DocumentOwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            // DocumentPlot_DocumentOwnerRelashionship configuration
            modelBuilder.Entity<DocumentPlot_DocumentOwnerRelashionship>()
         .HasKey(dpo => new { dpo.DocumentPlotId, dpo.DocumentOwnerID });

            // Relationship configuration for DocumentPlot
            modelBuilder.Entity<DocumentPlot_DocumentOwnerRelashionship>()
                .HasOne(dpo => dpo.DocumentPlot)
                .WithMany(dp => dp.documentPlot_DocumentOwnerRelashionships) // Ensure the navigation property is configured in Plot_DocumentOfOwnershipRelashionship
                .HasForeignKey(dpo => dpo.DocumentPlotId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete to DocumentPlot

            // Relationship configuration for DocumentOwner
            modelBuilder.Entity<DocumentPlot_DocumentOwnerRelashionship>()
                .HasOne(dpo => dpo.DocumentOwner)
                .WithMany(owner => owner.documentPlot_DocumentOwnerRelashionships) // Ensure the navigation property is configured in DocumentOfOwnership_OwnerRelashionship
                .HasForeignKey(dpo => dpo.DocumentOwnerID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion


            #region SeedRoles
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

            #region Seed activity and task types

            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType { ActivityTypeID = 1, ActivityTypeName = "Проект за изменение на КК" },
                new ActivityType { ActivityTypeID = 2, ActivityTypeName = "Комбинирана скица" },
                new ActivityType { ActivityTypeID = 3, ActivityTypeName = "Трасиране на имот" },
                new ActivityType { ActivityTypeID = 4, ActivityTypeName = "Заснемане по чл.54а ЗКИР" },
                new ActivityType { ActivityTypeID = 5, ActivityTypeName = "Изработване на ССО" },
                new ActivityType { ActivityTypeID = 6, ActivityTypeName = "Снимка за проектиране" },
                new ActivityType { ActivityTypeID = 7, ActivityTypeName = "Заснемане на обект /ограда, сграда/ за проверка" },
                new ActivityType { ActivityTypeID = 8, ActivityTypeName = "Заснемоне по чл.116 ЗУТ / линейни обекти/" },
                new ActivityType { ActivityTypeID = 9, ActivityTypeName = "Заснемане на обект чл.159 ЗУТ /за съответствие/" },
                new ActivityType { ActivityTypeID = 10, ActivityTypeName = "Издаване на скица" },
                new ActivityType { ActivityTypeID = 11, ActivityTypeName = "Издаване на удостоверение с характеристики на имота" },
                new ActivityType { ActivityTypeID = 12, ActivityTypeName = "Заснемане на обект § 16 ПР ЗУТ /за търпимост/" },
                new ActivityType { ActivityTypeID = 13, ActivityTypeName = "Заснемане на обект чрез фотограметрия" },
                new ActivityType { ActivityTypeID = 14, ActivityTypeName = "Архитектурно заснемане на обект" },
                new ActivityType { ActivityTypeID = 15, ActivityTypeName = "Трасиране на сграда" },
                new ActivityType { ActivityTypeID = 16, ActivityTypeName = "Трасиране на линеен обект" },
                new ActivityType { ActivityTypeID = 17, ActivityTypeName = "Част геодезия към инвестиционен проект" },
                new ActivityType { ActivityTypeID = 18, ActivityTypeName = "Схема за монтаж" },
                new ActivityType { ActivityTypeID = 19, ActivityTypeName = "Трасировъчен план за допълващо застрояване" },
                new ActivityType { ActivityTypeID = 20, ActivityTypeName = "Трасировъчен план за оград" },
                new ActivityType { ActivityTypeID = 21, ActivityTypeName = "Изменение на КРНИ" },
                new ActivityType { ActivityTypeID = 22, ActivityTypeName = "Изготвяне на  оферта за услуги" },
                new ActivityType { ActivityTypeID = 23, ActivityTypeName = "Подробен устройствен план" },
                new ActivityType { ActivityTypeID = 24, ActivityTypeName = "Процедура по промяна на предназначение или препотвърждаване на изтекло решение по чл.17 ЗОЗЗ на имот с влязъл в сила ПУП" },
                new ActivityType { ActivityTypeID = 25, ActivityTypeName = "Изменение на ПНИ" },
                new ActivityType { ActivityTypeID = 26, ActivityTypeName = "Изработване на протокол за максимален наклон" },
                new ActivityType { ActivityTypeID = 27, ActivityTypeName = "Протокол за съборена сграда" },
                new ActivityType { ActivityTypeID = 28, ActivityTypeName = "Трасировъчен план за линеен обект /ЕЛ, ВиК проводи/" },
                new ActivityType { ActivityTypeID = 29, ActivityTypeName = "Схема за монтаж на обекти в АПП на морски плажове" },
                new ActivityType { ActivityTypeID = 30, ActivityTypeName = "Програма за водно спасителна дейност" }
            );

            modelBuilder.Entity<TaskType>().HasData(
                new TaskType { TaskTypeId = 1, TaskTypeName = "Трасиране правото на собственост", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 2, TaskTypeName = "Протокол за трасиране", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 3, TaskTypeName = "Заявка за cad файл от КК", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 4, TaskTypeName = "Заверка на протокол със копие от действащ ПУП в общинска администрация", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 5, TaskTypeName = "Комбинирана скица", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 6, TaskTypeName = "Изработване на проект за измение на КК", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 7, TaskTypeName = "Входиране на проекта в АГКК за приемане", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 8, TaskTypeName = "Протокол за приемане на проекта", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 9, TaskTypeName = "Издаване на скица след изменение ", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 10, TaskTypeName = "предаване на клиент", ActivityTypeID = 1 },
                new TaskType { TaskTypeId = 11, TaskTypeName = "Заявка за cad файл от КК", ActivityTypeID = 2 },
                new TaskType { TaskTypeId = 12, TaskTypeName = "Заявление за копие от  необходими планове в общинска администрация", ActivityTypeID = 2 },
                new TaskType { TaskTypeId = 13, TaskTypeName = "Изработване на комбинирана скица ", ActivityTypeID = 2 },
                new TaskType { TaskTypeId = 14, TaskTypeName = "Изпращане за съгласуване ", ActivityTypeID = 2 },
                new TaskType { TaskTypeId = 15, TaskTypeName = "предаване на клиент", ActivityTypeID = 2 },
                new TaskType { TaskTypeId = 16, TaskTypeName = "анализ на документите", ActivityTypeID = 3 },
                new TaskType { TaskTypeId = 17, TaskTypeName = "трасиране ", ActivityTypeID = 3 },
                new TaskType { TaskTypeId = 18, TaskTypeName = "Протокол за трасиране", ActivityTypeID = 3 },
                new TaskType { TaskTypeId = 19, TaskTypeName = "предаване на клиент", ActivityTypeID = 3 },
                new TaskType { TaskTypeId = 20, TaskTypeName = "анализ на документите", ActivityTypeID = 4 },
                new TaskType { TaskTypeId = 21, TaskTypeName = "геодезическо заснемане", ActivityTypeID = 4 },
                new TaskType { TaskTypeId = 22, TaskTypeName = "обработка на извършени измервания и изготвяне на проект за изменение на КК", ActivityTypeID = 4 },
                new TaskType { TaskTypeId = 23, TaskTypeName = "Входиране на проекта в АГКК за приемане", ActivityTypeID = 4 },
                new TaskType { TaskTypeId = 24, TaskTypeName = "Протокол за приемане на проекта", ActivityTypeID = 4 },
                new TaskType { TaskTypeId = 25, TaskTypeName = "предаване на клиент", ActivityTypeID = 4 },
                new TaskType { TaskTypeId = 26, TaskTypeName = "анализ на документите", ActivityTypeID = 5 },
                new TaskType { TaskTypeId = 27, TaskTypeName = "площообразуване", ActivityTypeID = 5 },
                new TaskType { TaskTypeId = 28, TaskTypeName = "изработване на проект за нанасяне на ССО", ActivityTypeID = 5 },
                new TaskType { TaskTypeId = 29, TaskTypeName = "Входиране на проекта в АГКК за приемане", ActivityTypeID = 5 },
                new TaskType { TaskTypeId = 30, TaskTypeName = "Протокол за приемане на проекта", ActivityTypeID = 5 },
                new TaskType { TaskTypeId = 31, TaskTypeName = "предаване на клиент", ActivityTypeID = 5 },
                new TaskType { TaskTypeId = 32, TaskTypeName = "анализ на документите", ActivityTypeID = 6 },
                new TaskType { TaskTypeId = 33, TaskTypeName = "геодезическо заснемане", ActivityTypeID = 6 },
                new TaskType { TaskTypeId = 34, TaskTypeName = "обработка на извършени измервания", ActivityTypeID = 6 },
                new TaskType { TaskTypeId = 35, TaskTypeName = "изпращане на водещия проектант на обекта", ActivityTypeID = 6 },
                new TaskType { TaskTypeId = 36, TaskTypeName = "анализ на документите", ActivityTypeID = 7 },
                new TaskType { TaskTypeId = 37, TaskTypeName = "геодезическо заснемане", ActivityTypeID = 7 },
                new TaskType { TaskTypeId = 38, TaskTypeName = "обработка на извършени измервания", ActivityTypeID = 7 },
                new TaskType { TaskTypeId = 39, TaskTypeName = "предаване на клиент на хартиен носител", ActivityTypeID = 7 },
                new TaskType { TaskTypeId = 40, TaskTypeName = "анализ на документите", ActivityTypeID = 8 },
                new TaskType { TaskTypeId = 41, TaskTypeName = "геодезическо заснемане", ActivityTypeID = 8 },
                new TaskType { TaskTypeId = 42, TaskTypeName = "обработка на извършени измервания", ActivityTypeID = 8 },
                new TaskType { TaskTypeId = 43, TaskTypeName = "Оформяне за предаване", ActivityTypeID = 8 },
                new TaskType { TaskTypeId = 44, TaskTypeName = "предаване ", ActivityTypeID = 8 },
                new TaskType { TaskTypeId = 45, TaskTypeName = "анализ на документите", ActivityTypeID = 9 },
                new TaskType { TaskTypeId = 46, TaskTypeName = "геодезическо заснемане", ActivityTypeID = 9 },
                new TaskType { TaskTypeId = 47, TaskTypeName = "обработка на извършени измервания", ActivityTypeID = 9 },
                new TaskType { TaskTypeId = 48, TaskTypeName = "Оформяне за предаване", ActivityTypeID = 9 },
                new TaskType { TaskTypeId = 49, TaskTypeName = "анализ на документите", ActivityTypeID = 10 },
                new TaskType { TaskTypeId = 50, TaskTypeName = "входиране на заявление в КК", ActivityTypeID = 10 },
                new TaskType { TaskTypeId = 51, TaskTypeName = "предаване на клиент", ActivityTypeID = 10 },
                new TaskType { TaskTypeId = 52, TaskTypeName = "анализ на документите", ActivityTypeID = 11 },
                new TaskType { TaskTypeId = 53, TaskTypeName = "входиране на заявление в КК", ActivityTypeID = 11 },
                new TaskType { TaskTypeId = 54, TaskTypeName = "предаване на клиент", ActivityTypeID = 11 },
                new TaskType { TaskTypeId = 55, TaskTypeName = "анализ на документите", ActivityTypeID = 12 },
                new TaskType { TaskTypeId = 56, TaskTypeName = "геодезическо заснемане", ActivityTypeID = 12 },
                new TaskType { TaskTypeId = 57, TaskTypeName = "обработка на извършени измервания", ActivityTypeID = 12 },
                new TaskType { TaskTypeId = 58, TaskTypeName = "изпращане на водещия проектант на обекта", ActivityTypeID = 12 },
                new TaskType { TaskTypeId = 59, TaskTypeName = "Оформяне за предаване", ActivityTypeID = 12 },
                new TaskType { TaskTypeId = 60, TaskTypeName = "анализ на документите", ActivityTypeID = 13 },
                new TaskType { TaskTypeId = 61, TaskTypeName = "полски дейности", ActivityTypeID = 13 },
                new TaskType { TaskTypeId = 62, TaskTypeName = "обработка на извършени измервания", ActivityTypeID = 13 },
                new TaskType { TaskTypeId = 63, TaskTypeName = "изпратена за преглед и потвърждение", ActivityTypeID = 13 },
                new TaskType { TaskTypeId = 64, TaskTypeName = "предаване на клиент", ActivityTypeID = 13 },
                new TaskType { TaskTypeId = 65, TaskTypeName = "анализ на документите", ActivityTypeID = 14 },
                new TaskType { TaskTypeId = 66, TaskTypeName = "полски дейности", ActivityTypeID = 14 },
                new TaskType { TaskTypeId = 67, TaskTypeName = "канцеларска обработка", ActivityTypeID = 14 },
                new TaskType { TaskTypeId = 68, TaskTypeName = "предаване на клиент", ActivityTypeID = 14 },
                new TaskType { TaskTypeId = 69, TaskTypeName = "анализ на документите", ActivityTypeID = 15 },
                new TaskType { TaskTypeId = 70, TaskTypeName = "подготовка на данни", ActivityTypeID = 15 },
                new TaskType { TaskTypeId = 71, TaskTypeName = "полски дейности", ActivityTypeID = 15 },
                new TaskType { TaskTypeId = 72, TaskTypeName = "анализ на документите", ActivityTypeID = 16 },
                new TaskType { TaskTypeId = 73, TaskTypeName = "подготовка на данни", ActivityTypeID = 16 },
                new TaskType { TaskTypeId = 74, TaskTypeName = "полски дейности", ActivityTypeID = 16 },
                new TaskType { TaskTypeId = 75, TaskTypeName = "анализ на файлове от водещия проектант", ActivityTypeID = 17 },
                new TaskType { TaskTypeId = 76, TaskTypeName = "изработване на проект ВП и ТП", ActivityTypeID = 17 },
                new TaskType { TaskTypeId = 77, TaskTypeName = "изпращане на водещия проектант за съгласуване", ActivityTypeID = 17 },
                new TaskType { TaskTypeId = 78, TaskTypeName = "Оформяне за предаване", ActivityTypeID = 17 },
                new TaskType { TaskTypeId = 79, TaskTypeName = "предаване на клиент", ActivityTypeID = 17 },
                new TaskType { TaskTypeId = 80, TaskTypeName = "анализ на документите", ActivityTypeID = 18 },
                new TaskType { TaskTypeId = 81, TaskTypeName = "изработване на схема за монтаж", ActivityTypeID = 18 },
                new TaskType { TaskTypeId = 82, TaskTypeName = "предаване на клиент", ActivityTypeID = 18 },
                new TaskType { TaskTypeId = 83, TaskTypeName = "анализ на документите", ActivityTypeID = 19 },
                new TaskType { TaskTypeId = 84, TaskTypeName = "изработване на ТП", ActivityTypeID = 19 },
                new TaskType { TaskTypeId = 85, TaskTypeName = "предаване на клиент", ActivityTypeID = 19 },
                new TaskType { TaskTypeId = 86, TaskTypeName = "анализ на документите", ActivityTypeID = 20 },
                new TaskType { TaskTypeId = 87, TaskTypeName = "изработване на ТП", ActivityTypeID = 20 },
                new TaskType { TaskTypeId = 88, TaskTypeName = "предаване на клиент", ActivityTypeID = 20 },
                new TaskType { TaskTypeId = 89, TaskTypeName = "входиране на заявление в КК", ActivityTypeID = 21 },
                new TaskType { TaskTypeId = 90, TaskTypeName = "анализ на документите", ActivityTypeID = 22 },
                new TaskType { TaskTypeId = 91, TaskTypeName = "изготвяне на оферта", ActivityTypeID = 22 },
                new TaskType { TaskTypeId = 92, TaskTypeName = "изготвяне на графично предложение", ActivityTypeID = 22 },
                new TaskType { TaskTypeId = 93, TaskTypeName = "изпращане на клиента", ActivityTypeID = 22 },
                new TaskType { TaskTypeId = 94, TaskTypeName = "Скица на имота", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 95, TaskTypeName = "удостоверение с характеристика", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 96, TaskTypeName = "удостоверение за УЗ по ОУП", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 97, TaskTypeName = "Извадка от КК / ПР / ЗП", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 98, TaskTypeName = "изработване на задание за проектиране и графично предложение по чл.135 ЗУТ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 99, TaskTypeName = "Проучване за присъединяване с ЕВН", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 100, TaskTypeName = "Проучване за присъединяване с ВиК", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 101, TaskTypeName = "Уведомление за план-програма до РИОСВ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 102, TaskTypeName = "възлагане изработване на доклад за преценка от ЕО/ОВОС", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 103, TaskTypeName = "получаване на доклад и входиране в РИОСВ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 104, TaskTypeName = "Получаване на решение за преценка от РИОСВ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 105, TaskTypeName = "Писмо за влязло в сила решение на РИОСВ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 106, TaskTypeName = "Съгласуване с НИНКН", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 107, TaskTypeName = "Входиране на искане за Допускане на ПУП", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 108, TaskTypeName = "Получаване на заповед за Допускане на ПУП", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 109, TaskTypeName = "Изработване на ПУП", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 110, TaskTypeName = "възлагане на план схема ВиК", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 111, TaskTypeName = "Получаване на план схема ВиК", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 112, TaskTypeName = "Съгласуване на план схема ВиК", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 113, TaskTypeName = "Възлагане на план схема ЕЛ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 114, TaskTypeName = "Получаване на план схема ЕЛ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 115, TaskTypeName = "Съгласуване на план схема ЕЛ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 116, TaskTypeName = "Получаване на план схема озеленяване", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 117, TaskTypeName = "Изработване на ПУП", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 118, TaskTypeName = "Входиране на ПУП с план схеми за приемане на ОЕСУТ", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 119, TaskTypeName = "подписване на уведомление в общинска администрация", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 120, TaskTypeName = "Проект за съгласуване на ПУП с КК по чл.65 Наредба №РД-02-20-5-2016г.", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 121, TaskTypeName = "Заповед за одобряване на ПУП", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 122, TaskTypeName = "подписване на уведомление в общинска администрация", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 123, TaskTypeName = "Получаване на преписката от общинска администрация", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 124, TaskTypeName = "Скица проект от АГКК", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 125, TaskTypeName = "Актуализация на проект в КК", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 126, TaskTypeName = "предаване на клиент", ActivityTypeID = 23 },
                new TaskType { TaskTypeId = 127, TaskTypeName = "анализ на документите", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 128, TaskTypeName = "Скица на имота", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 129, TaskTypeName = "удостоверение с характеристика", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 130, TaskTypeName = "удостоверение за УЗ по ОУП", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 131, TaskTypeName = "инвестиционно намерение до РИОСВ", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 132, TaskTypeName = "Удостоверение за поливност", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 133, TaskTypeName = "Акт за категоризация", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 134, TaskTypeName = "Съгласеване с НИНКН", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 135, TaskTypeName = "Изработване и съгласуване на план-схема Вик при необходимост", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 136, TaskTypeName = "Здравно заключение от РЗИ", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 137, TaskTypeName = "Входиране на преписката в комисията по чл.17 ЗОЗЗ", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 138, TaskTypeName = "Решение на комия по чл.17 ЗОЗЗ", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 139, TaskTypeName = "заплащане на определената такса", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 140, TaskTypeName = "получаване на преписката от ОДЗ", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 141, TaskTypeName = "предаване на клиент", ActivityTypeID = 24 },
                new TaskType { TaskTypeId = 142, TaskTypeName = "анализ на документите", ActivityTypeID = 25 },
                new TaskType { TaskTypeId = 143, TaskTypeName = "получаване на изходна информация от общинска администрация /модел и поредни номера/", ActivityTypeID = 25 },
                new TaskType { TaskTypeId = 144, TaskTypeName = "изработване на проект за измение на ПНИ", ActivityTypeID = 25 },
                new TaskType { TaskTypeId = 145, TaskTypeName = "предаване на клиент", ActivityTypeID = 25 },
                new TaskType { TaskTypeId = 146, TaskTypeName = "изработване на протокол", ActivityTypeID = 26 },
                new TaskType { TaskTypeId = 147, TaskTypeName = "предаване на клиент", ActivityTypeID = 26 },
                new TaskType { TaskTypeId = 148, TaskTypeName = "анализ на документите", ActivityTypeID = 27 },
                new TaskType { TaskTypeId = 149, TaskTypeName = "проверка на терен", ActivityTypeID = 27 },
                new TaskType { TaskTypeId = 150, TaskTypeName = "изготвяне на протокол", ActivityTypeID = 27 },
                new TaskType { TaskTypeId = 151, TaskTypeName = "предаване на клиент", ActivityTypeID = 27 },
                new TaskType { TaskTypeId = 152, TaskTypeName = "анализ на документите и файлове от водещ проектант", ActivityTypeID = 28 },
                new TaskType { TaskTypeId = 153, TaskTypeName = "Изработванен на ТП", ActivityTypeID = 28 },
                new TaskType { TaskTypeId = 154, TaskTypeName = "Оформяне за предаване", ActivityTypeID = 28 },
                new TaskType { TaskTypeId = 155, TaskTypeName = "предаване на клиент", ActivityTypeID = 28 },
                new TaskType { TaskTypeId = 156, TaskTypeName = "анализ на документите", ActivityTypeID = 29 },
                new TaskType { TaskTypeId = 157, TaskTypeName = "изработване на схема за монтаж", ActivityTypeID = 29 },
                new TaskType { TaskTypeId = 158, TaskTypeName = "съгласуване с възложител", ActivityTypeID = 29 },
                new TaskType { TaskTypeId = 159, TaskTypeName = "Оформяне за предаване", ActivityTypeID = 29 },
                new TaskType { TaskTypeId = 160, TaskTypeName = "предаване на клиент", ActivityTypeID = 29 },
                new TaskType { TaskTypeId = 161, TaskTypeName = "анализ на документите", ActivityTypeID = 30 },
                new TaskType { TaskTypeId = 162, TaskTypeName = "изработване на протграмата", ActivityTypeID = 30 },
                new TaskType { TaskTypeId = 163, TaskTypeName = "съгласуване с възложител", ActivityTypeID = 30 },
                new TaskType { TaskTypeId = 164, TaskTypeName = "Оформяне за предаване", ActivityTypeID = 30 },
                new TaskType { TaskTypeId = 165, TaskTypeName = "предаване на клиент", ActivityTypeID = 30 }
            );

            #endregion
        }
    }
}
