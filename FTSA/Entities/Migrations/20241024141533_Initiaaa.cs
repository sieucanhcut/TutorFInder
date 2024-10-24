using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initiaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("26c57f2c-ec53-4d08-92c9-44416c3c9285"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("2725dcf3-2216-476c-a6f6-cc7d9b4b8c05"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("d8bad377-4dcd-40bd-b4ea-7733b8ec4ef5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("2e0cad2b-e47b-4417-b664-927a79b6e2e0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("6d755edc-96ed-44c4-8df5-b8c7f2056352"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e65cc6f9-77fa-410d-8980-70d8f27063af"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f6c6ca3e-c4b1-4d54-bbb7-aa46d6105c7f"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CityOrProvince", "District", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1ce5c0d6-5acc-4a09-bf59-361df192ea00"), "Da Nang", "Hai Chau", null },
                    { new Guid("29095f8f-605a-4877-9f6c-1a800f6411eb"), "Da Nang", "Thank Khe", null },
                    { new Guid("7db94b62-a70b-49aa-a6aa-bb9e195b382b"), "Da Nang", "Son Tra", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("3e92dded-a10b-453a-9722-a3ca49600a07"), "Blocked", "None" },
                    { new Guid("69a02bf2-dbab-482d-a084-c938fd2a66de"), "Tutor", "None" },
                    { new Guid("a4b5dd68-eadc-4e28-9aeb-06919f16641a"), "Admin", "None" },
                    { new Guid("f63cd496-d966-4989-887e-c9e69ec1e3ed"), "Student", "None" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("1ce5c0d6-5acc-4a09-bf59-361df192ea00"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("29095f8f-605a-4877-9f6c-1a800f6411eb"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7db94b62-a70b-49aa-a6aa-bb9e195b382b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("3e92dded-a10b-453a-9722-a3ca49600a07"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("69a02bf2-dbab-482d-a084-c938fd2a66de"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a4b5dd68-eadc-4e28-9aeb-06919f16641a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f63cd496-d966-4989-887e-c9e69ec1e3ed"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CityOrProvince", "District", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("26c57f2c-ec53-4d08-92c9-44416c3c9285"), "Da Nang", "Son Tra", null },
                    { new Guid("2725dcf3-2216-476c-a6f6-cc7d9b4b8c05"), "Da Nang", "Hai Chau", null },
                    { new Guid("d8bad377-4dcd-40bd-b4ea-7733b8ec4ef5"), "Da Nang", "Thank Khe", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("2e0cad2b-e47b-4417-b664-927a79b6e2e0"), "Student", "None" },
                    { new Guid("6d755edc-96ed-44c4-8df5-b8c7f2056352"), "Admin", "None" },
                    { new Guid("e65cc6f9-77fa-410d-8980-70d8f27063af"), "Blocked", "None" },
                    { new Guid("f6c6ca3e-c4b1-4d54-bbb7-aa46d6105c7f"), "Tutor", "None" }
                });
        }
    }
}
