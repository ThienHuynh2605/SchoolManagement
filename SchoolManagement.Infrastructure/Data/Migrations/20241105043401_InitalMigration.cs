using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeTown = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "Email", "HomeTown", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown1", "Student1" },
                    { 2, new DateTime(2003, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown2", "Student2" },
                    { 3, new DateTime(2002, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown3", "Student3" },
                    { 4, new DateTime(2005, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown4", "Student4" },
                    { 5, new DateTime(2002, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown0", "Student5" },
                    { 6, new DateTime(2003, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown1", "Student6" },
                    { 7, new DateTime(2004, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown2", "Student7" },
                    { 8, new DateTime(2005, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown3", "Student8" },
                    { 9, new DateTime(2005, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown4", "Student9" },
                    { 10, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeTown0", "Student10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
