using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Plots",
                columns: table => new
                {
                    PlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlotNumber = table.Column<int>(type: "int", nullable: false),
                    RegulatedPlotNumber = table.Column<int>(type: "int", nullable: true),
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
                name: "WorkObjects",
                columns: table => new
                {
                    WorkObjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkObjects", x => x.WorkObjectId);
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
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    WorkObjectId = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedDuration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_WorkObjects_WorkObjectId",
                        column: x => x.WorkObjectId,
                        principalTable: "WorkObjects",
                        principalColumn: "WorkObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_WorkObjectRelashionships",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    WorkObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_WorkObjectRelashionships", x => new { x.EmployeeId, x.WorkObjectId });
                    table.ForeignKey(
                        name: "FK_Employee_WorkObjectRelashionships_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_WorkObjectRelashionships_WorkObjects_WorkObjectId",
                        column: x => x.WorkObjectId,
                        principalTable: "WorkObjects",
                        principalColumn: "WorkObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Object_PlotRelashionships",
                columns: table => new
                {
                    WorkObjectId = table.Column<int>(type: "int", nullable: false),
                    PlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object_PlotRelashionships", x => new { x.WorkObjectId, x.PlotId });
                    table.ForeignKey(
                        name: "FK_Object_PlotRelashionships_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "PlotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Object_PlotRelashionships_WorkObjects_WorkObjectId",
                        column: x => x.WorkObjectId,
                        principalTable: "WorkObjects",
                        principalColumn: "WorkObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request_WorkObjectRelashionships",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    WorkObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_WorkObjectRelashionships", x => new { x.RequestId, x.WorkObjectId });
                    table.ForeignKey(
                        name: "FK_Request_WorkObjectRelashionships_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_WorkObjectRelashionships_WorkObjects_WorkObjectId",
                        column: x => x.WorkObjectId,
                        principalTable: "WorkObjects",
                        principalColumn: "WorkObjectId",
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
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_ExecutantId",
                        column: x => x.ExecutantId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RequestId",
                table: "Activities",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_WorkObjectId",
                table: "Activities",
                column: "WorkObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_RequestRelashionships_ClientId",
                table: "Client_RequestRelashionships",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WorkObjectRelashionships_WorkObjectId",
                table: "Employee_WorkObjectRelashionships",
                column: "WorkObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RequestId",
                table: "Invoices",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Object_PlotRelashionships_PlotId",
                table: "Object_PlotRelashionships",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_WorkObjectRelashionships_WorkObjectId",
                table: "Request_WorkObjectRelashionships",
                column: "WorkObjectId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_RequestRelashionships");

            migrationBuilder.DropTable(
                name: "Employee_WorkObjectRelashionships");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Object_PlotRelashionships");

            migrationBuilder.DropTable(
                name: "Request_WorkObjectRelashionships");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "WorkObjects");
        }
    }
}
