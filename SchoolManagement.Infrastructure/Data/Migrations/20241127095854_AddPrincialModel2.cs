using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrincialModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrincipalsAccounts_Principals_PrincipalId",
                table: "PrincipalsAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrincipalsAccounts",
                table: "PrincipalsAccounts");

            migrationBuilder.RenameTable(
                name: "PrincipalsAccounts",
                newName: "PrincipalAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_PrincipalsAccounts_PrincipalId",
                table: "PrincipalAccounts",
                newName: "IX_PrincipalAccounts_PrincipalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrincipalAccounts",
                table: "PrincipalAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrincipalAccounts_Principals_PrincipalId",
                table: "PrincipalAccounts",
                column: "PrincipalId",
                principalTable: "Principals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrincipalAccounts_Principals_PrincipalId",
                table: "PrincipalAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrincipalAccounts",
                table: "PrincipalAccounts");

            migrationBuilder.RenameTable(
                name: "PrincipalAccounts",
                newName: "PrincipalsAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_PrincipalAccounts_PrincipalId",
                table: "PrincipalsAccounts",
                newName: "IX_PrincipalsAccounts_PrincipalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrincipalsAccounts",
                table: "PrincipalsAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrincipalsAccounts_Principals_PrincipalId",
                table: "PrincipalsAccounts",
                column: "PrincipalId",
                principalTable: "Principals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
