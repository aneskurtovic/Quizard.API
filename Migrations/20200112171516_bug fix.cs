using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "2b1ad060-3ffc-4470-91c1-a534dd3a6296");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5f1f66f3-a1f8-4f65-bd4c-7239a2070c3d", "AQAAAAEAACcQAAAAEKhAX4lE5IBprDvy4LcXQxFK3tMYgLmT9AAjzvH8AfBXuhd9W2CS1hMz4G7oD7KZHg==" });
        }
    }
}
