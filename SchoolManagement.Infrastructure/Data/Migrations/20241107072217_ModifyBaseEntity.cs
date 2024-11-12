using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Students",
                newName: "IsActive");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2004, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2003, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2002, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2003, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2005, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2002, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2005, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2003, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2004, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateOfBirth", "IsActive" },
                values: new object[] { new DateTime(2002, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Students",
                newName: "IsDeleted");

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
    }
}
