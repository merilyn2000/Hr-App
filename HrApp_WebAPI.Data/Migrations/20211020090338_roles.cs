using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApp_WebAPI.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e72f4a2d-4043-4f3e-9763-ffcfc1efbe84", "f19cfb50-37c7-40e4-b9bc-cb083370826e", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8230eb63-100d-4cb3-8fb1-6b7b0fe3ada8", "2db4b7e9-c79f-4e18-b0a9-d029fbda7148", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "215f329d-6ec5-414c-b3fc-808ebccc8693", "fc57bbc1-1b19-451a-84b6-93f45f4e2ca6", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "215f329d-6ec5-414c-b3fc-808ebccc8693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8230eb63-100d-4cb3-8fb1-6b7b0fe3ada8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e72f4a2d-4043-4f3e-9763-ffcfc1efbe84");
        }
    }
}
