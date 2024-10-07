using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SFS.Migrations
{
    /// <inheritdoc />
    public partial class seeddefaultvaluestoclassteacherscheduletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Focus on precise body movements and alignment for flexibility.", "Pilates" },
                    { 2, "Balance body and mind with guided stretches and breathing.", "Yoga" },
                    { 3, "Boost your stamina with high-intensity interval training.", "HIIT" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Expertise", "Name" },
                values: new object[,]
                {
                    { 1, "Yoga", "Emily Green" },
                    { 2, "Pilates", "David White" },
                    { 3, "HIIT", "Sarah Black" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ClassId", "EndTime", "MaxCapacity", "StartTime", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 9, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, new DateTime(2024, 9, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2024, 9, 11, 10, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, new DateTime(2024, 9, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2024, 9, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);
        }
    }
}
