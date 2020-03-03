using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class AddedselectedanswersIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Answers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "427ae65b-d165-4ba9-8412-3e4b5a888eb7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa069305-598c-48d5-bb22-71a90a0f5cb6", "AQAAAAEAACcQAAAAECEt1MOMhiVI6zScDHndWiEbta0m/gr6+vkorZ2waa0AlC2fE+eFLeo9jbEl53PGcQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SessionId",
                table: "Answers",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Sessions_SessionId",
                table: "Answers",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Sessions_SessionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_SessionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Timer",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Answers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "7727ff29-6490-4808-a872-6709da3f8328");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4379479-1fbd-4dcc-9251-99e8c35f0d05", "AQAAAAEAACcQAAAAEGKEXUl/I2UfCuuJ1IKMKWdM9uyKdc2j5bMsHI6If/lGKte6o9pTJa8XIk84GzpMbw==" });
        }
    }
}
