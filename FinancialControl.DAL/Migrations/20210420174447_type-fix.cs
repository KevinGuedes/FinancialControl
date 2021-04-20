using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialControl.DAL.Migrations
{
    public partial class typefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "d541f6d3-5a88-4075-89f6-4a7098409234");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "e731003e-d708-42ee-af9a-a2ddaee8cf81");

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d730d358-1d71-43ec-832d-ee679b6b56db", "d519837d-5461-4fab-970a-b80b69d155e3", "System Administrator", "Administrator", "ADMINISTRATOR" },
                    { "8ba78da3-0c12-4912-b1ec-becbc5aaa1bb", "0e7b617a-0671-4f91-8c4a-af8f4177ae92", "System User", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Expenditure");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Profit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "8ba78da3-0c12-4912-b1ec-becbc5aaa1bb");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "d730d358-1d71-43ec-832d-ee679b6b56db");

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e731003e-d708-42ee-af9a-a2ddaee8cf81", "eb96ad68-4fea-4c90-924d-c73fba1e9f5d", "System Administrator", "Administrator", "ADMINISTRATOR" },
                    { "d541f6d3-5a88-4075-89f6-4a7098409234", "5e5c071a-0fc2-4b61-b78f-a5eff175bab0", "System User", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Expenditures");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Profits");
        }
    }
}
