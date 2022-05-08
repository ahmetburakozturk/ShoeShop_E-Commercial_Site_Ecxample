using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ShoeShop.DataAccess.Migrations
{
    public partial class db_upd5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Gender_GenderID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.AlterColumn<int>(
                name: "GenderID",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genders_GenderID",
                table: "Products",
                column: "GenderID",
                principalTable: "Genders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genders_GenderID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.AlterColumn<int>(
                name: "GenderID",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Gender_GenderID",
                table: "Products",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
