using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.DataAccess.Migrations
{
    public partial class upd015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Products",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Material",
                table: "Products");
        }
    }
}
