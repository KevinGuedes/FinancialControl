using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialControl.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "21ba904c-9470-4daf-bc44-ee7f9d08a777");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "4a41415f-db7b-4224-907b-80655be4effc");

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "e731003e-d708-42ee-af9a-a2ddaee8cf81", "eb96ad68-4fea-4c90-924d-c73fba1e9f5d", "System Administrator", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "d541f6d3-5a88-4075-89f6-4a7098409234", "5e5c071a-0fc2-4b61-b78f-a5eff175bab0", "System User", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4a41415f-db7b-4224-907b-80655be4effc", "e6326b89-1725-4138-bda5-8f1f778cccea", "System Administrator", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "21ba904c-9470-4daf-bc44-ee7f9d08a777", "e76961cc-504f-4767-a156-7f82daf8bdc5", "System User", "User", "USER" });
        }
    }
}
