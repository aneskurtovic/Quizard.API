using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class Categorysetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "40fe8265-c37f-4db1-8293-0d678a1696df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a961f71-ff54-4fc3-aa6c-ff9c9d80da92", "AQAAAAEAACcQAAAAEFuj43nQlZslZSIv/Bn9BxDhICOOa3KEqcRzbe6T1G8LzdKE7zREMXDhmfo3c9uuqw==" });
        }
    }
}
