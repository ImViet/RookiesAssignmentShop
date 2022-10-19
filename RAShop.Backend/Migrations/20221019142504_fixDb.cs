using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAShop.Backend.Migrations
{
    public partial class fixDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductImages_ProdImgId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProdImgId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductImages_ProdImgId",
                table: "Products",
                column: "ProdImgId",
                principalTable: "ProductImages",
                principalColumn: "ProdImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductImages_ProdImgId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProdImgId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductImages_ProdImgId",
                table: "Products",
                column: "ProdImgId",
                principalTable: "ProductImages",
                principalColumn: "ProdImageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
