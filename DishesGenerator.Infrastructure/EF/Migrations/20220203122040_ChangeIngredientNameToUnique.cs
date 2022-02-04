using Microsoft.EntityFrameworkCore.Migrations;

namespace DishesGenerator.Infrastructure.EF.Migrations
{
    public partial class ChangeIngredientNameToUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IngredientInfo_Name",
                table: "IngredientInfo",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IngredientInfo_Name",
                table: "IngredientInfo");
        }
    }
}
