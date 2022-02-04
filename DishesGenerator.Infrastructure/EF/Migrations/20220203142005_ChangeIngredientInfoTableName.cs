using Microsoft.EntityFrameworkCore.Migrations;

namespace DishesGenerator.Infrastructure.EF.Migrations
{
    public partial class ChangeIngredientInfoTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_IngredientInfo_IngredientInfoId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientInfo",
                table: "IngredientInfo");

            migrationBuilder.RenameTable(
                name: "IngredientInfo",
                newName: "IngredientsInfos");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientInfo_Name",
                table: "IngredientsInfos",
                newName: "IX_IngredientsInfos_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsInfos",
                table: "IngredientsInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_IngredientsInfos_IngredientInfoId",
                table: "DishIngredients",
                column: "IngredientInfoId",
                principalTable: "IngredientsInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_IngredientsInfos_IngredientInfoId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsInfos",
                table: "IngredientsInfos");

            migrationBuilder.RenameTable(
                name: "IngredientsInfos",
                newName: "IngredientInfo");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsInfos_Name",
                table: "IngredientInfo",
                newName: "IX_IngredientInfo_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientInfo",
                table: "IngredientInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_IngredientInfo_IngredientInfoId",
                table: "DishIngredients",
                column: "IngredientInfoId",
                principalTable: "IngredientInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
