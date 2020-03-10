using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class Difficultylevelupdating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "e72f0b65-718e-4d57-9872-4e81435afb9e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7442a50c-7901-4899-ae60-0ab267f68d18", "AQAAAAEAACcQAAAAEGoEQ005/OsDQKVJ6Hyeks7B3rSUdj+qZbEGKE/wqfzee79i/+qjgQR1jcXzMo8guA==" });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Medium" },
                    { 3, "Hard" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "38f788c5-5cef-4091-8ed6-f32c13f9674d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19103be9-bd21-4836-a882-9915a720cb33", "AQAAAAEAACcQAAAAEIoQg8eEn2fq8kn2STQO7iE1K4RqU1RhhVuQE56n6/7bOhVyN+31zfycT2GHSQi1rw==" });
        }
    }
}
