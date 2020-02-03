using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class Manytomanyquizquestionrelationshipaddedagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Questions_QuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Quizzes_QuizId",
                table: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion");

            migrationBuilder.RenameTable(
                name: "QuizQuestion",
                newName: "QuizzesQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestion_QuizId",
                table: "QuizzesQuestions",
                newName: "IX_QuizzesQuestions_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizzesQuestions",
                table: "QuizzesQuestions",
                columns: new[] { "QuestionId", "QuizId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzesQuestions_Questions_QuestionId",
                table: "QuizzesQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzesQuestions_Quizzes_QuizId",
                table: "QuizzesQuestions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizzesQuestions_Questions_QuestionId",
                table: "QuizzesQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizzesQuestions_Quizzes_QuizId",
                table: "QuizzesQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizzesQuestions",
                table: "QuizzesQuestions");

            migrationBuilder.RenameTable(
                name: "QuizzesQuestions",
                newName: "QuizQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_QuizzesQuestions_QuizId",
                table: "QuizQuestion",
                newName: "IX_QuizQuestion_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion",
                columns: new[] { "QuestionId", "QuizId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "dbe4ac4b-5956-45cd-85e5-2c94b4620fe8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "722153ee-235e-4fe7-a3a2-b18ed4c43a96", "AQAAAAEAACcQAAAAEIR+pXzgzABfvxDAXTGE8CBC7s4uxnG82b9+i/7k194Y+EbXse1b9+UIXzKG1Sg6IQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Questions_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Quizzes_QuizId",
                table: "QuizQuestion",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
