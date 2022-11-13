using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarModelId1",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarModelId1",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId1",
                table: "Cars",
                column: "CarModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId1",
                table: "Cars",
                column: "CarModelId1",
                principalTable: "CarModels",
                principalColumn: "Id");
        }
    }
}
