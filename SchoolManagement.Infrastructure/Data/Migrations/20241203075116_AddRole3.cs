using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRole3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "TeacherAccounts");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "StudentAccounts");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "PrincipalAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "TeacherAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "StudentAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "PrincipalAccounts",
                type: "int",
                nullable: true);
        }
    }
}
