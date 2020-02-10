using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class ForeignKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "a20ae644-9ca4-4231-8f9f-3cc828d695a3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5539d2d-753a-41bc-8ec0-8fd76f27eb63", "AQAAAAEAACcQAAAAENy1TwOYmYgEY3hVDfu3BzMubg8JM3yzAavZvhI4HY6x2EuZDQpFfMHsmUr/UowDNw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "e2f0481d-8caf-4832-88ef-e3dfb94dff55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8dbe793e-fff3-4d69-b9cc-61cd415ed57e", "AQAAAAEAACcQAAAAEJQLDreOitWtOfD5LCh5WNQmljapnNB1ba0McBiSqCTlFmNw5mHerP8rTciur5AMuw==" });
        }
    }
}
