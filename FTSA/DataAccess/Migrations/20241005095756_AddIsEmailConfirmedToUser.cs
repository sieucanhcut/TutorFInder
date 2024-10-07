using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsEmailConfirmedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("5481b121-4d13-4abb-aacd-a0ebf1a0bc33"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("ab9791ae-788f-4152-a259-b62a79ed99e0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("af14ed60-5699-4172-ae56-16b32c274caf"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("6ec884e6-e6c1-4db3-9c21-b4b9302c8bd1"), "Admin", "None" },
                    { new Guid("714e6594-7cc4-430f-bfba-bab0b109dc18"), "Tutor", "None" },
                    { new Guid("945014d0-5a78-4b09-97ca-d7ba5a199173"), "Student", "None" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("6ec884e6-e6c1-4db3-9c21-b4b9302c8bd1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("714e6594-7cc4-430f-bfba-bab0b109dc18"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("945014d0-5a78-4b09-97ca-d7ba5a199173"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("5481b121-4d13-4abb-aacd-a0ebf1a0bc33"), "Tutor", "None" },
                    { new Guid("ab9791ae-788f-4152-a259-b62a79ed99e0"), "Student", "None" },
                    { new Guid("af14ed60-5699-4172-ae56-16b32c274caf"), "Admin", "None" }
                });
        }
    }
}
