using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizard.API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Correct",
                table: "Answers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Correct",
                table: "Answers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "fc10d3ff-21ff-4ccd-af60-71cd598211cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0c513be9-9e48-44e4-870d-66116b322f87", "AQAAAAEAACcQAAAAEBEqRaFO1tfklevKESPDsXnQ6ydEPK9xO+MnCxVemajittCLMRzUv1MMWJ8DiNj3Yw==" });
        }
    }
}
