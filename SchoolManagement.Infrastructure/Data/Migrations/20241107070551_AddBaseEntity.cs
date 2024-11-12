using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2003, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2003, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2004, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2004, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2003, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2002, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2003, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2004, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2005, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateOfBirth", "IsDeleted" },
                values: new object[] { new DateTime(2003, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2004, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2005, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2004, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2004, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2005, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfBirth",
                value: new DateTime(2002, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfBirth",
                value: new DateTime(2005, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateOfBirth",
                value: new DateTime(2002, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateOfBirth",
                value: new DateTime(2004, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
