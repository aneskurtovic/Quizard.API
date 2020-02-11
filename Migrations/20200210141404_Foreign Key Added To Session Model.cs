using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class ForeignKeyAddedToSessionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "8dab5885-a286-4c70-84ba-f21f518a6d17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ba7ed79-d395-4d9c-97ec-0b99dd604ad3", "AQAAAAEAACcQAAAAEN7BjJXBPrOpdIz2u4MMTp3KIH8EKzIIqmbdzfuP1tNH361tcc+V+dXKwDOMrjQ2rA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_QuizId",
                table: "Sessions",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Quizzes_QuizId",
                table: "Sessions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Quizzes_QuizId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_QuizId",
                table: "Sessions");

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
    }
}
