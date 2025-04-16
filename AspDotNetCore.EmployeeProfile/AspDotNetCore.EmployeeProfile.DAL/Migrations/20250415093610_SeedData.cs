using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspDotNetCore.EmployeeProfile.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "DateCreated", "Email", "EmployeeName", "Gender", "State" },
                values: new object[] { 1, new DateOnly(1994, 1, 14), new DateTime(2025, 4, 15, 15, 6, 9, 271, DateTimeKind.Local).AddTicks(8394), "Employee1@gmail.com", "Employee1", "F", "Pune" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Roles", "UserName" },
                values: new object[,]
                {
                    { 1, "1111", "Admin", "testuser1" },
                    { 2, "2222", "Developer", "testuser2" },
                    { 3, "3333", "Moderator", "testuser3" },
                    { 4, "4444", "SubAdmin", "testuser4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
