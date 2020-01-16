using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class Categorydb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "141019ce-ec58-4846-beaf-9136af9b449b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa3da27e-09ee-441d-9277-c59d95932b9a", "AQAAAAEAACcQAAAAELMMHKtwNTQV5B7XwvjXyeEKucDsBf9b85rI0sXe1gh63b8tZVoCsTJ3NGBSmwA9Yg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "952bee6d-5bc3-43ed-ac26-b923ad7a7566");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0dc9834-6a38-44fc-8d39-1ee787f0a30d", "AQAAAAEAACcQAAAAEJF09HlrpVOQ8WzMDcjOlfU+DnvleiBBF1g79I6Zxhp0BL3hRMOSbB+xLBp80fcRxg==" });
        }
    }
}
