using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class AdicionandoCustomUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 150,
                column: "ConcurrencyStamp",
                value: "58f3e04a-1af9-41f5-a6e4-f259887c9aaa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999,
                column: "ConcurrencyStamp",
                value: "0381a220-78f5-432b-93a2-4d004ff20670");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6933fbf9-8a43-4b2d-baf7-0d4c9a0152ac", "AQAAAAEAACcQAAAAED3eStTucty7X0yvhozl3QIB0WLHmSzJPSBMzHSt9YWxGWPzXtMaG+XaS31dF2P7OA==", "fb020ca9-a043-45af-8abb-98a5b7aad4a2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 150,
                column: "ConcurrencyStamp",
                value: "ed8e43e4-8988-4480-8ef0-8a81d65449df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999,
                column: "ConcurrencyStamp",
                value: "565e2e1e-46d6-4571-8620-917e6f769a9b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5618582-5396-4341-90fb-c30ea42f82aa", "AQAAAAEAACcQAAAAEFasWB9EbSMDyteFafKFTmpU8Bv7+MIbITxv/j28ZcM9tlH1jGJcZwcxOjeN74+zqw==", "4f2f46da-0921-4de1-8bda-661c0bb5d9e9" });
        }
    }
}
