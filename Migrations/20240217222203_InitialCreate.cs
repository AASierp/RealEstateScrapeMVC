using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateScrapeMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    SqureFeet = table.Column<int>(type: "INTEGER", nullable: false),
                    LotSize = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertySearchModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    County0 = table.Column<string>(type: "TEXT", nullable: false),
                    County1 = table.Column<string>(type: "TEXT", nullable: false),
                    County2 = table.Column<string>(type: "TEXT", nullable: false),
                    County3 = table.Column<string>(type: "TEXT", nullable: false),
                    County4 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySearchModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyModels");

            migrationBuilder.DropTable(
                name: "PropertySearchModels");
        }
    }
}
