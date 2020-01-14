using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class hehe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "b309ae01-d22a-45ba-8a62-1213ea7548ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2db79073-2821-4c6c-8a71-b3ca2b306dea", "AQAAAAEAACcQAAAAEK+wHCp9FBLJAo1aelsuqjPCBBhTHdozJFoSramgkTWoedQ62LFUFIqa8HO03FlqGg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
