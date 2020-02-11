using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class Sessionmodelnamingproblemssolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "QuizTakerName",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Sessions");

            migrationBuilder.AddColumn<string>(
                name: "ContestantName",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Sessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "Sessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "3e745a4d-19b3-4ca9-bdf2-4eeca3188005");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "123592c9-8d6b-4c23-902a-3a9ed6462c22", "AQAAAAEAACcQAAAAEL4Q6mhPirXHosANs/yASW+oBBLDHiR8LnabivqdyY/vIZbeNYOTxMKmLnNQgPKMYg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContestantName",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "Sessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "QuizTakerName",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
