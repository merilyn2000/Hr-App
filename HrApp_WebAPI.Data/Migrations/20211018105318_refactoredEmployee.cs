using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApp_WebAPI.Migrations
{
    public partial class refactoredEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PersonalDatas_PersonalDatasId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "PersonalDatas");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PersonalDatasId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PersonalDatasId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "AWALA",
                table: "Employees",
                newName: "PersonalIdentificationNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PersonalIdentificationNumber",
                table: "Employees",
                newName: "AWALA");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDatasId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonalDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDatas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonalDatasId",
                table: "Employees",
                column: "PersonalDatasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PersonalDatas_PersonalDatasId",
                table: "Employees",
                column: "PersonalDatasId",
                principalTable: "PersonalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
