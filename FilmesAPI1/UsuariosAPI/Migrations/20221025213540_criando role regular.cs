using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999,
                column: "ConcurrencyStamp",
                value: "ed60d207-2fa2-409d-ba3d-5e09b16717dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 150, "141662a5-32bb-4a8b-a69a-4c1e938f5401", "relugar", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51bfa365-a1a8-4352-9ffd-de597613f68f", "AQAAAAEAACcQAAAAEAWlDXHWbRSz0jiOv5D2PPSsW0KQLHVz8rzJgELMaQUxpLPrMhYoVzLKS346xaFPwA==", "7d32d998-d845-462a-9d30-306f730f73eb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999,
                column: "ConcurrencyStamp",
                value: "99a635ce-f5c5-4461-828f-1cc051c41ce0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a95315d9-c34f-47e6-99f0-e49dca546fd9", "AQAAAAEAACcQAAAAEJpHCMmdf8hLRXhdX6hPc2PTFqZPUBp2VR2E61FTDp+yZzkM+edimBGvM6JEMVV+3Q==", "82ba6219-7716-4108-9e67-908db2ddeb45" });
        }
    }
}
