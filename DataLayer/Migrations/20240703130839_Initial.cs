using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activityTypes",
                columns: table => new
                {
                    ActivityTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activityTypes", x => x.ActivityTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientLegalType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsOfOwnership",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOM = table.Column<int>(type: "int", nullable: false),
                    register = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocCase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssuing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRegistering = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsOfOwnership", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EGN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    PlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlotNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegulatedPlotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: true),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.PlotId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Advance = table.Column<float>(type: "real", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "taskTypes",
                columns: table => new
                {
                    TaskTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskTypes", x => x.TaskTypeId);
                    table.ForeignKey(
                        name: "FK_taskTypes_activityTypes_ActivityTypeID",
                        column: x => x.ActivityTypeID,
                        principalTable: "activityTypes",
                        principalColumn: "ActivityTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentOfOwnership_OwnerRelashionships",
                columns: table => new
                {
                    DocumentOwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentOfOwnership_OwnerRelashionships", x => x.DocumentOwnerID);
                    table.ForeignKey(
                        name: "FK_DocumentOfOwnership_OwnerRelashionships_DocumentsOfOwnership_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "DocumentsOfOwnership",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentOfOwnership_OwnerRelashionships_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "OwnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plot_DocumentOfOwnerships",
                columns: table => new
                {
                    DocumentPlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlotId = table.Column<int>(type: "int", nullable: false),
                    DocumentOfOwnershipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plot_DocumentOfOwnerships", x => x.DocumentPlotId);
                    table.ForeignKey(
                        name: "FK_Plot_DocumentOfOwnerships_DocumentsOfOwnership_DocumentOfOwnershipId",
                        column: x => x.DocumentOfOwnershipId,
                        principalTable: "DocumentsOfOwnership",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plot_DocumentOfOwnerships_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "PlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ActivityTypeID = table.Column<int>(type: "int", nullable: false),
                    ExpectedDuration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Activities_ParentActivityId",
                        column: x => x.ParentActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId");
                    table.ForeignKey(
                        name: "FK_Activities_activityTypes_ActivityTypeID",
                        column: x => x.ActivityTypeID,
                        principalTable: "activityTypes",
                        principalColumn: "ActivityTypeID");
                    table.ForeignKey(
                        name: "FK_Activities_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                });

            migrationBuilder.CreateTable(
                name: "Client_RequestRelashionships",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    OwnershipType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_RequestRelashionships", x => new { x.RequestId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_Client_RequestRelashionships_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_RequestRelashionships_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documentPlot_DocumentOwenerRelashionships",
                columns: table => new
                {
                    DocumentPlotId = table.Column<int>(type: "int", nullable: false),
                    DocumentOwnerID = table.Column<int>(type: "int", nullable: false),
                    IdealParts = table.Column<float>(type: "real", nullable: false),
                    WayOfAcquiring = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentPlot_DocumentOwenerRelashionships", x => new { x.DocumentPlotId, x.DocumentOwnerID });
                    table.ForeignKey(
                        name: "FK_documentPlot_DocumentOwenerRelashionships_DocumentOfOwnership_OwnerRelashionships_DocumentOwnerID",
                        column: x => x.DocumentOwnerID,
                        principalTable: "DocumentOfOwnership_OwnerRelashionships",
                        principalColumn: "DocumentOwnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documentPlot_DocumentOwenerRelashionships_Plot_DocumentOfOwnerships_DocumentPlotId",
                        column: x => x.DocumentPlotId,
                        principalTable: "Plot_DocumentOfOwnerships",
                        principalColumn: "DocumentPlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity_PlotRelashionships",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    PlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity_PlotRelashionships", x => new { x.ActivityId, x.PlotId });
                    table.ForeignKey(
                        name: "FK_Activity_PlotRelashionships_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_PlotRelashionships_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "PlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutantId = table.Column<int>(type: "int", nullable: false),
                    ControlId = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId");
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_ExecutantId",
                        column: x => x.ExecutantId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Tasks_taskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "taskTypes",
                        principalColumn: "TaskTypeId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "admin", "Admin" },
                    { "2", "2", "user", "User" }
                });

            migrationBuilder.InsertData(
                table: "activityTypes",
                columns: new[] { "ActivityTypeID", "ActivityTypeName" },
                values: new object[,]
                {
                    { 1, "Проект за изменение на КК" },
                    { 2, "Комбинирана скица" },
                    { 3, "Трасиране на имот" },
                    { 4, "Заснемане по чл.54а ЗКИР" },
                    { 5, "Изработване на ССО" },
                    { 6, "Снимка за проектиране" },
                    { 7, "Заснемане на обект /ограда, сграда/ за проверка" },
                    { 8, "Заснемоне по чл.116 ЗУТ / линейни обекти/" },
                    { 9, "Заснемане на обект чл.159 ЗУТ /за съответствие/" },
                    { 10, "Издаване на скица" },
                    { 11, "Издаване на удостоверение с характеристики на имота" },
                    { 12, "Заснемане на обект § 16 ПР ЗУТ /за търпимост/" },
                    { 13, "Заснемане на обект чрез фотограметрия" },
                    { 14, "Архитектурно заснемане на обект" },
                    { 15, "Трасиране на сграда" },
                    { 16, "Трасиране на линеен обект" },
                    { 17, "Част геодезия към инвестиционен проект" },
                    { 18, "Схема за монтаж" },
                    { 19, "Трасировъчен план за допълващо застрояване" },
                    { 20, "Трасировъчен план за оград" },
                    { 21, "Изменение на КРНИ" },
                    { 22, "Изготвяне на  оферта за услуги" },
                    { 23, "Подробен устройствен план" },
                    { 24, "Процедура по промяна на предназначение или препотвърждаване на изтекло решение по чл.17 ЗОЗЗ на имот с влязъл в сила ПУП" },
                    { 25, "Изменение на ПНИ" },
                    { 26, "Изработване на протокол за максимален наклон" },
                    { 27, "Протокол за съборена сграда" },
                    { 28, "Трасировъчен план за линеен обект /ЕЛ, ВиК проводи/" },
                    { 29, "Схема за монтаж на обекти в АПП на морски плажове" },
                    { 30, "Програма за водно спасителна дейност" }
                });

            migrationBuilder.InsertData(
                table: "taskTypes",
                columns: new[] { "TaskTypeId", "ActivityTypeID", "TaskTypeName" },
                values: new object[,]
                {
                    { 1, 1, "Трасиране правото на собственост" },
                    { 2, 1, "Протокол за трасиране" },
                    { 3, 1, "Заявка за cad файл от КК" },
                    { 4, 1, "Заверка на протокол със копие от действащ ПУП в общинска администрация" },
                    { 5, 1, "Комбинирана скица" },
                    { 6, 1, "Изработване на проект за измение на КК" },
                    { 7, 1, "Входиране на проекта в АГКК за приемане" },
                    { 8, 1, "Протокол за приемане на проекта" },
                    { 9, 1, "Издаване на скица след изменение " },
                    { 10, 1, "предаване на клиент" },
                    { 11, 2, "Заявка за cad файл от КК" },
                    { 12, 2, "Заявление за копие от  необходими планове в общинска администрация" },
                    { 13, 2, "Изработване на комбинирана скица " },
                    { 14, 2, "Изпращане за съгласуване " },
                    { 15, 2, "предаване на клиент" },
                    { 16, 3, "анализ на документите" },
                    { 17, 3, "трасиране " },
                    { 18, 3, "Протокол за трасиране" },
                    { 19, 3, "предаване на клиент" },
                    { 20, 4, "анализ на документите" },
                    { 21, 4, "геодезическо заснемане" },
                    { 22, 4, "обработка на извършени измервания и изготвяне на проект за изменение на КК" },
                    { 23, 4, "Входиране на проекта в АГКК за приемане" },
                    { 24, 4, "Протокол за приемане на проекта" },
                    { 25, 4, "предаване на клиент" },
                    { 26, 5, "анализ на документите" },
                    { 27, 5, "площообразуване" },
                    { 28, 5, "изработване на проект за нанасяне на ССО" },
                    { 29, 5, "Входиране на проекта в АГКК за приемане" },
                    { 30, 5, "Протокол за приемане на проекта" },
                    { 31, 5, "предаване на клиент" },
                    { 32, 6, "анализ на документите" },
                    { 33, 6, "геодезическо заснемане" },
                    { 34, 6, "обработка на извършени измервания" },
                    { 35, 6, "изпращане на водещия проектант на обекта" },
                    { 36, 7, "анализ на документите" },
                    { 37, 7, "геодезическо заснемане" },
                    { 38, 7, "обработка на извършени измервания" },
                    { 39, 7, "предаване на клиент на хартиен носител" },
                    { 40, 8, "анализ на документите" },
                    { 41, 8, "геодезическо заснемане" },
                    { 42, 8, "обработка на извършени измервания" }
                });

            migrationBuilder.InsertData(
                table: "taskTypes",
                columns: new[] { "TaskTypeId", "ActivityTypeID", "TaskTypeName" },
                values: new object[,]
                {
                    { 43, 8, "Оформяне за предаване" },
                    { 44, 8, "предаване " },
                    { 45, 9, "анализ на документите" },
                    { 46, 9, "геодезическо заснемане" },
                    { 47, 9, "обработка на извършени измервания" },
                    { 48, 9, "Оформяне за предаване" },
                    { 49, 10, "анализ на документите" },
                    { 50, 10, "входиране на заявление в КК" },
                    { 51, 10, "предаване на клиент" },
                    { 52, 11, "анализ на документите" },
                    { 53, 11, "входиране на заявление в КК" },
                    { 54, 11, "предаване на клиент" },
                    { 55, 12, "анализ на документите" },
                    { 56, 12, "геодезическо заснемане" },
                    { 57, 12, "обработка на извършени измервания" },
                    { 58, 12, "изпращане на водещия проектант на обекта" },
                    { 59, 12, "Оформяне за предаване" },
                    { 60, 13, "анализ на документите" },
                    { 61, 13, "полски дейности" },
                    { 62, 13, "обработка на извършени измервания" },
                    { 63, 13, "изпратена за преглед и потвърждение" },
                    { 64, 13, "предаване на клиент" },
                    { 65, 14, "анализ на документите" },
                    { 66, 14, "полски дейности" },
                    { 67, 14, "канцеларска обработка" },
                    { 68, 14, "предаване на клиент" },
                    { 69, 15, "анализ на документите" },
                    { 70, 15, "подготовка на данни" },
                    { 71, 15, "полски дейности" },
                    { 72, 16, "анализ на документите" },
                    { 73, 16, "подготовка на данни" },
                    { 74, 16, "полски дейности" },
                    { 75, 17, "анализ на файлове от водещия проектант" },
                    { 76, 17, "изработване на проект ВП и ТП" },
                    { 77, 17, "изпращане на водещия проектант за съгласуване" },
                    { 78, 17, "Оформяне за предаване" },
                    { 79, 17, "предаване на клиент" },
                    { 80, 18, "анализ на документите" },
                    { 81, 18, "изработване на схема за монтаж" },
                    { 82, 18, "предаване на клиент" },
                    { 83, 19, "анализ на документите" },
                    { 84, 19, "изработване на ТП" }
                });

            migrationBuilder.InsertData(
                table: "taskTypes",
                columns: new[] { "TaskTypeId", "ActivityTypeID", "TaskTypeName" },
                values: new object[,]
                {
                    { 85, 19, "предаване на клиент" },
                    { 86, 20, "анализ на документите" },
                    { 87, 20, "изработване на ТП" },
                    { 88, 20, "предаване на клиент" },
                    { 89, 21, "входиране на заявление в КК" },
                    { 90, 22, "анализ на документите" },
                    { 91, 22, "изготвяне на оферта" },
                    { 92, 22, "изготвяне на графично предложение" },
                    { 93, 22, "изпращане на клиента" },
                    { 94, 23, "Скица на имота" },
                    { 95, 23, "удостоверение с характеристика" },
                    { 96, 23, "удостоверение за УЗ по ОУП" },
                    { 97, 23, "Извадка от КК / ПР / ЗП" },
                    { 98, 23, "изработване на задание за проектиране и графично предложение по чл.135 ЗУТ" },
                    { 99, 23, "Проучване за присъединяване с ЕВН" },
                    { 100, 23, "Проучване за присъединяване с ВиК" },
                    { 101, 23, "Уведомление за план-програма до РИОСВ" },
                    { 102, 23, "възлагане изработване на доклад за преценка от ЕО/ОВОС" },
                    { 103, 23, "получаване на доклад и входиране в РИОСВ" },
                    { 104, 23, "Получаване на решение за преценка от РИОСВ" },
                    { 105, 23, "Писмо за влязло в сила решение на РИОСВ" },
                    { 106, 23, "Съгласуване с НИНКН" },
                    { 107, 23, "Входиране на искане за Допускане на ПУП" },
                    { 108, 23, "Получаване на заповед за Допускане на ПУП" },
                    { 109, 23, "Изработване на ПУП" },
                    { 110, 23, "възлагане на план схема ВиК" },
                    { 111, 23, "Получаване на план схема ВиК" },
                    { 112, 23, "Съгласуване на план схема ВиК" },
                    { 113, 23, "Възлагане на план схема ЕЛ" },
                    { 114, 23, "Получаване на план схема ЕЛ" },
                    { 115, 23, "Съгласуване на план схема ЕЛ" },
                    { 116, 23, "Получаване на план схема озеленяване" },
                    { 117, 23, "Изработване на ПУП" },
                    { 118, 23, "Входиране на ПУП с план схеми за приемане на ОЕСУТ" },
                    { 119, 23, "подписване на уведомление в общинска администрация" },
                    { 120, 23, "Проект за съгласуване на ПУП с КК по чл.65 Наредба №РД-02-20-5-2016г." },
                    { 121, 23, "Заповед за одобряване на ПУП" },
                    { 122, 23, "подписване на уведомление в общинска администрация" },
                    { 123, 23, "Получаване на преписката от общинска администрация" },
                    { 124, 23, "Скица проект от АГКК" },
                    { 125, 23, "Актуализация на проект в КК" },
                    { 126, 23, "предаване на клиент" }
                });

            migrationBuilder.InsertData(
                table: "taskTypes",
                columns: new[] { "TaskTypeId", "ActivityTypeID", "TaskTypeName" },
                values: new object[,]
                {
                    { 127, 24, "анализ на документите" },
                    { 128, 24, "Скица на имота" },
                    { 129, 24, "удостоверение с характеристика" },
                    { 130, 24, "удостоверение за УЗ по ОУП" },
                    { 131, 24, "инвестиционно намерение до РИОСВ" },
                    { 132, 24, "Удостоверение за поливност" },
                    { 133, 24, "Акт за категоризация" },
                    { 134, 24, "Съгласеване с НИНКН" },
                    { 135, 24, "Изработване и съгласуване на план-схема Вик при необходимост" },
                    { 136, 24, "Здравно заключение от РЗИ" },
                    { 137, 24, "Входиране на преписката в комисията по чл.17 ЗОЗЗ" },
                    { 138, 24, "Решение на комия по чл.17 ЗОЗЗ" },
                    { 139, 24, "заплащане на определената такса" },
                    { 140, 24, "получаване на преписката от ОДЗ" },
                    { 141, 24, "предаване на клиент" },
                    { 142, 25, "анализ на документите" },
                    { 143, 25, "получаване на изходна информация от общинска администрация /модел и поредни номера/" },
                    { 144, 25, "изработване на проект за измение на ПНИ" },
                    { 145, 25, "предаване на клиент" },
                    { 146, 26, "изработване на протокол" },
                    { 147, 26, "предаване на клиент" },
                    { 148, 27, "анализ на документите" },
                    { 149, 27, "проверка на терен" },
                    { 150, 27, "изготвяне на протокол" },
                    { 151, 27, "предаване на клиент" },
                    { 152, 28, "анализ на документите и файлове от водещ проектант" },
                    { 153, 28, "Изработванен на ТП" },
                    { 154, 28, "Оформяне за предаване" },
                    { 155, 28, "предаване на клиент" },
                    { 156, 29, "анализ на документите" },
                    { 157, 29, "изработване на схема за монтаж" },
                    { 158, 29, "съгласуване с възложител" },
                    { 159, 29, "Оформяне за предаване" },
                    { 160, 29, "предаване на клиент" },
                    { 161, 30, "анализ на документите" },
                    { 162, 30, "изработване на протграмата" },
                    { 163, 30, "съгласуване с възложител" },
                    { 164, 30, "Оформяне за предаване" },
                    { 165, 30, "предаване на клиент" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeID",
                table: "Activities",
                column: "ActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ParentActivityId",
                table: "Activities",
                column: "ParentActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RequestId",
                table: "Activities",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_PlotRelashionships_PlotId",
                table: "Activity_PlotRelashionships",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Client_RequestRelashionships_ClientId",
                table: "Client_RequestRelashionships",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentOfOwnership_OwnerRelashionships_DocumentID",
                table: "DocumentOfOwnership_OwnerRelashionships",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentOfOwnership_OwnerRelashionships_OwnerID",
                table: "DocumentOfOwnership_OwnerRelashionships",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_documentPlot_DocumentOwenerRelashionships_DocumentOwnerID",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "DocumentOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RequestId",
                table: "Invoices",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Plot_DocumentOfOwnerships_DocumentOfOwnershipId",
                table: "Plot_DocumentOfOwnerships",
                column: "DocumentOfOwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Plot_DocumentOfOwnerships_PlotId",
                table: "Plot_DocumentOfOwnerships",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ActivityId",
                table: "Tasks",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ControlId",
                table: "Tasks",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutantId",
                table: "Tasks",
                column: "ExecutantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_taskTypes_ActivityTypeID",
                table: "taskTypes",
                column: "ActivityTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_PlotRelashionships");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Client_RequestRelashionships");

            migrationBuilder.DropTable(
                name: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DocumentOfOwnership_OwnerRelashionships");

            migrationBuilder.DropTable(
                name: "Plot_DocumentOfOwnerships");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "taskTypes");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "DocumentsOfOwnership");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "activityTypes");
        }
    }
}
