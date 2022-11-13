using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Cars_Id",
                table: "CarModels");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CarModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CarModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Cars_Id",
                table: "CarModels",
                column: "Id",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
