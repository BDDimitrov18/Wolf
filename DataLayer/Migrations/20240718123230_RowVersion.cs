using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_DocumentOfOwnership_OwnerRelashionships_DocumentOwnerID",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_Plot_DocumentOfOwnerships_DocumentPlotId",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "taskTypes",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Tasks",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Requests",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "powerOfAttorneyDocuments",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Plots",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Plot_DocumentOfOwnerships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Owners",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Invoices",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "files",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Employees",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "DocumentsOfOwnership",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "documentPlot_DocumentOwenerRelashionships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "DocumentOfOwnership_OwnerRelashionships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Clients",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Client_RequestRelashionships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "activityTypes",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Activity_PlotRelashionships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Activities",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_DocumentOfOwnership_OwnerRelashionships_DocumentOwnerID",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "DocumentOwnerID",
                principalTable: "DocumentOfOwnership_OwnerRelashionships",
                principalColumn: "DocumentOwnerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_Plot_DocumentOfOwnerships_DocumentPlotId",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "DocumentPlotId",
                principalTable: "Plot_DocumentOfOwnerships",
                principalColumn: "DocumentPlotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "PowerOfAttorneyId",
                principalTable: "powerOfAttorneyDocuments",
                principalColumn: "PowerOfAttorneyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_DocumentOfOwnership_OwnerRelashionships_DocumentOwnerID",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_Plot_DocumentOfOwnerships_DocumentPlotId",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "taskTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "powerOfAttorneyDocuments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Plot_DocumentOfOwnerships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "files");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "DocumentsOfOwnership");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "DocumentOfOwnership_OwnerRelashionships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Client_RequestRelashionships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "activityTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Activity_PlotRelashionships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_DocumentOfOwnership_OwnerRelashionships_DocumentOwnerID",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "DocumentOwnerID",
                principalTable: "DocumentOfOwnership_OwnerRelashionships",
                principalColumn: "DocumentOwnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_Plot_DocumentOfOwnerships_DocumentPlotId",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "DocumentPlotId",
                principalTable: "Plot_DocumentOfOwnerships",
                principalColumn: "DocumentPlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "PowerOfAttorneyId",
                principalTable: "powerOfAttorneyDocuments",
                principalColumn: "PowerOfAttorneyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
