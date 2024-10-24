using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("23499f3e-cfff-40ab-8611-ffeda0db2a37"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("8726fe2e-192a-4459-a00e-cf93fe9fc180"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("ec2b13d3-78a6-4655-83a4-6130a33e37c7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b75fb7f6-80a2-452e-a404-1fbead5d9f3a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("c5391f19-7a4c-46a8-9447-14d8fb3c0754"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f9011393-aba2-4d9d-bc51-7ebe56e89faa"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CityOrProvince", "District", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("23499f3e-cfff-40ab-8611-ffeda0db2a37"), "Da Nang", "Thank Khe", null },
                    { new Guid("8726fe2e-192a-4459-a00e-cf93fe9fc180"), "Da Nang", "Son Tra", null },
                    { new Guid("ec2b13d3-78a6-4655-83a4-6130a33e37c7"), "Da Nang", "Hai Chau", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("b75fb7f6-80a2-452e-a404-1fbead5d9f3a"), "Student", "None" },
                    { new Guid("c5391f19-7a4c-46a8-9447-14d8fb3c0754"), "Tutor", "None" },
                    { new Guid("f9011393-aba2-4d9d-bc51-7ebe56e89faa"), "Admin", "None" }
                });
        }
    }
}
