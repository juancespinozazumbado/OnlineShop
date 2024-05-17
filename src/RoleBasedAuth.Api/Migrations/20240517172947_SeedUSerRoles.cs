using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoleBasedAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedUSerRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10001", null, "Admin", "ADMIN" },
                    { "10002", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "43a6c712-0954-42c5-8fba-3eeebcf2f9c2", 0, "31e3cee2-b4a7-4b2c-bd01-05553f6145f9", "admin@shop.com", true, false, null, "ADMIN@SHOP.COM", "ADMIN", "AQAAAAIAAYagAAAAEHI16NaSRasTmxdqpappVuRopkFgpsJrukpHC2Kc7dZHUmOyg3u28Zl0zogqJikSxA==", null, false, "d8b87b1c-dfd5-476d-89c8-66a2c876392e", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "10001", "43a6c712-0954-42c5-8fba-3eeebcf2f9c2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10002");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10001", "43a6c712-0954-42c5-8fba-3eeebcf2f9c2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a6c712-0954-42c5-8fba-3eeebcf2f9c2");
        }
    }
}
