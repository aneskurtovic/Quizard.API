using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class CommentResolve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Correct",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Answers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "9634f5c6-fb31-4e21-9269-6565907f715d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "040ae44f-a5c4-4b3e-bf6a-8c1deaaf0eb6", "AQAAAAEAACcQAAAAEFNSrNndfUqB+ZhXPUmJppkTnGnxMOgQ3HBinFsZqSw0xGMcFfLpMZBrhxzRiWOBhw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Correct",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "410a4fa0-739c-418e-90a0-f5248574c6c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0389372-9496-4d40-8860-cf23153b9f15", "AQAAAAEAACcQAAAAEM4BYUQewgUGeI4JLWKcCh3DW9GpIN8LSwgEsqdTZRKGS8roOaSSmlJqs2o1QiFIkA==" });
        }
    }
}
