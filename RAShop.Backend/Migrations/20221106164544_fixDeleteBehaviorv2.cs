using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAShop.Backend.Migrations
{
    public partial class fixDeleteBehaviorv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CateId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CateId",
                table: "Products",
                column: "CateId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products",
                column: "SubCateId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CateId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CateId",
                table: "Products",
                column: "CateId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products",
                column: "SubCateId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId");
        }
    }
}
