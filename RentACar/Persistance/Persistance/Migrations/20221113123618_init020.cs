using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
