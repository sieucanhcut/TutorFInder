using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsEmailConfirmedToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("692dccae-956e-4b68-94fa-cdfa09b7cc9a"), "Admin", "None" },
                    { new Guid("6960404e-8e29-4b9d-8fdc-0c0f0f6cec35"), "Tutor", "None" },
                    { new Guid("93ed8d21-7b5c-494d-a4a7-d95abd2d3f9b"), "Student", "None" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("692dccae-956e-4b68-94fa-cdfa09b7cc9a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("6960404e-8e29-4b9d-8fdc-0c0f0f6cec35"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("93ed8d21-7b5c-494d-a4a7-d95abd2d3f9b"));

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "Users");

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
    }
}
