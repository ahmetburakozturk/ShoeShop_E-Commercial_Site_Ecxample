using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.DataAccess.Migrations
{
    public partial class mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genders_GenderID",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genders_GenderID",
                table: "Products",
                column: "GenderID",
                principalTable: "Genders",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genders_GenderID",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genders_GenderID",
                table: "Products",
                column: "GenderID",
                principalTable: "Genders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
