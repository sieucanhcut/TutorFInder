using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initiaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("2cfb9f7c-d742-416e-a7d5-ed0037e4a28c"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("581375c6-0c79-47e0-88a2-d6a44ec2c9a7"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("fa67b6a4-c2c0-48d7-84c9-0d9f9831966d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("097f1b4a-984a-4b23-8bff-bbe06676ec43"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("10faa75a-eb76-4e4e-ae47-e147dac61989"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("1108e4f0-5913-44ee-9c74-db3ae70b62cd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e3df00a3-29fa-4a74-b720-8698c2c682f8"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CityOrProvince", "District", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("2cfb9f7c-d742-416e-a7d5-ed0037e4a28c"), "Da Nang", "Son Tra", null },
                    { new Guid("581375c6-0c79-47e0-88a2-d6a44ec2c9a7"), "Da Nang", "Thank Khe", null },
                    { new Guid("fa67b6a4-c2c0-48d7-84c9-0d9f9831966d"), "Da Nang", "Hai Chau", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("097f1b4a-984a-4b23-8bff-bbe06676ec43"), "Blocked", "None" },
                    { new Guid("10faa75a-eb76-4e4e-ae47-e147dac61989"), "Student", "None" },
                    { new Guid("1108e4f0-5913-44ee-9c74-db3ae70b62cd"), "Admin", "None" },
                    { new Guid("e3df00a3-29fa-4a74-b720-8698c2c682f8"), "Tutor", "None" }
                });
        }
    }
}
