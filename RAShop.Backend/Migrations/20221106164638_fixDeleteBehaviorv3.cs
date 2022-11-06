using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAShop.Backend.Migrations
{
    public partial class fixDeleteBehaviorv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products",
                column: "SubCateId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCateId",
                table: "Products",
                column: "SubCateId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
