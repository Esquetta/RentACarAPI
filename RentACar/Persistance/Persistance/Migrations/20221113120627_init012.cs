using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Cars_Id",
                table: "CarModels");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Cars_Id",
                table: "CarModels",
                column: "Id",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Cars_Id",
                table: "CarModels");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Cars_Id",
                table: "CarModels",
                column: "Id",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
