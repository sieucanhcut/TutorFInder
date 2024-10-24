using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("6b5d770c-0203-49c3-aa6f-1025e520b37c"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("a55c9129-727d-4d76-9a54-ca4347670e0a"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("ac16f292-bb69-4960-b274-32952889350f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("4e4f18b3-c38f-433f-9e06-11d9c96cb314"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("922be63a-68b4-4a2a-b25d-601dab74b5a6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("94a8cb9f-9a74-48e2-b600-5e34b8084fc6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("fc0e323f-c365-4da7-a359-bcc90139e0cb"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("6b5d770c-0203-49c3-aa6f-1025e520b37c"), "Da Nang", "Son Tra", null },
                    { new Guid("a55c9129-727d-4d76-9a54-ca4347670e0a"), "Da Nang", "Thank Khe", null },
                    { new Guid("ac16f292-bb69-4960-b274-32952889350f"), "Da Nang", "Hai Chau", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("4e4f18b3-c38f-433f-9e06-11d9c96cb314"), "Student", "None" },
                    { new Guid("922be63a-68b4-4a2a-b25d-601dab74b5a6"), "Admin", "None" },
                    { new Guid("94a8cb9f-9a74-48e2-b600-5e34b8084fc6"), "Tutor", "None" },
                    { new Guid("fc0e323f-c365-4da7-a359-bcc90139e0cb"), "Blocked", "None" }
                });
        }
    }
}
