using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApp_WebAPI.Migrations
{
    public partial class updatedCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyLogo",
                table: "Companies",
                newName: "CompanyAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyAddress",
                table: "Companies",
                newName: "CompanyLogo");
        }
    }
}
