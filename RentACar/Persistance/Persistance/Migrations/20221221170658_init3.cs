using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaim_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaim",
                table: "OperationClaim");

            migrationBuilder.RenameTable(
                name: "OperationClaim",
                newName: "OperationClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims");

            migrationBuilder.RenameTable(
                name: "OperationClaims",
                newName: "OperationClaim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaim",
                table: "OperationClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaim_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
