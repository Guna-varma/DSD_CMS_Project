using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DSD_CMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CarModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carModelList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "longtext", nullable: false),
                    ModelCode = table.Column<string>(type: "longtext", nullable: false),
                    CarImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    FrontAngleImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    BackAngleImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    LeftAngleImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    RightAngleImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    FrontAngleLineImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    BackAngleLineImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    LeftAngleLineImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false),
                    RightAngleLineImage = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carModelList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carModelList");
        }
    }
}
