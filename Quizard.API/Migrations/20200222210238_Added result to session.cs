using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class Addedresulttosession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "Sessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "c4447d8c-ba4c-45be-9872-a820e2cb3031");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "316aa94f-e997-403f-851b-75e5f0f0e2c8", "AQAAAAEAACcQAAAAEG4sJzG/D6GVOLjRzS+dbmrlW7ZqA1x80AOldll1J/ugI6bIOSYlWyo60nocXpswmA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Sessions");

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
    }
}
