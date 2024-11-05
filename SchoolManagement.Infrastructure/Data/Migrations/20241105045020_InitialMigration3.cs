using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2003, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2004, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2005, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent3@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2004, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent4@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2004, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent5@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2005, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent6@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2002, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent7@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2005, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent8@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2002, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent9@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2004, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailStudent10@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2005, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2003, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2005, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2004, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2003, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2005, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2003, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2003, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2003, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateOfBirth", "Email" },
                values: new object[] { new DateTime(2005, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}
