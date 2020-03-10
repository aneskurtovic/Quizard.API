using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class Addedtimercolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Timer",
                table: "Quizzes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "4fe25169-e49f-46f5-8f03-f265ff82e9f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "faba7294-03b0-45d0-8b2a-733da028ee4d", "AQAAAAEAACcQAAAAEEaZdyZjutE7P60RatEtI+dOCbTgbz5R6BvT8/9LnnVT54l4FjHxNaWuSxjSa5UxCA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timer",
                table: "Quizzes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "fd2383ae-250c-4575-a8ee-5a93d95412f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd7cbbd4-d05f-4e14-a1f5-b05704105ce3", "AQAAAAEAACcQAAAAEDIqY7GugEcr4rflDFABX9BZA05/cGmgyisAROok0Mvg3zoEeQMYvJotPCocjlw47w==" });
        }
    }
}
