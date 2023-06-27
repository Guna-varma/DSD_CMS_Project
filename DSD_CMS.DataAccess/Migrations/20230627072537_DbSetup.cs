using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DSD_CMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DbSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "applicationImagesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AppImageTypes = table.Column<string>(type: "longtext", nullable: false),
                    AssetTitle = table.Column<string>(type: "longtext", nullable: false),
                    UploadAsset = table.Column<string>(type: "longtext", maxLength: 20971520, nullable: false),
                    UploadThumbImage = table.Column<string>(type: "longtext", maxLength: 20971520, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationImagesList", x => x.Id);
                })
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

            migrationBuilder.CreateTable(
                name: "dealersList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DealerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DealerLocation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealersList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "extrasList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ExtraCategories = table.Column<string>(type: "longtext", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Thumb = table.Column<string>(type: "longtext", maxLength: 20971520, nullable: false),
                    Asset = table.Column<string>(type: "longtext", maxLength: 20971520, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_extrasList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "feedbackQuestionsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackQuestionsList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "healthCardList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Customer = table.Column<string>(type: "longtext", nullable: false),
                    Mileage = table.Column<double>(type: "double", nullable: false),
                    TreadDepth = table.Column<string>(type: "longtext", nullable: false),
                    Breakpad = table.Column<string>(type: "longtext", nullable: false),
                    BreakDisc = table.Column<string>(type: "longtext", nullable: false),
                    Battery = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthCardList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insideInventoryList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InsideInventoryName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insideInventoryList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "interactiveCheckSheetsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(type: "longtext", nullable: false),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interactiveCheckSheetsList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "serviceProductList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ServiceProductName = table.Column<string>(type: "longtext", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceProductList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "settingsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PropertyName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PropertyValue = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settingsList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usersList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Mobile = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    LandLine = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserRole = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "variantList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VariantName = table.Column<string>(type: "longtext", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variantList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_variantList_carModelList_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "carModelList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "showroomsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ShowroomName = table.Column<string>(type: "longtext", nullable: false),
                    ShowroomLocation = table.Column<string>(type: "longtext", nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    FaxNo = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false),
                    Devices = table.Column<string>(type: "longtext", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showroomsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_showroomsList_dealersList_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "devicesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DeviceUDID = table.Column<string>(type: "longtext", nullable: false),
                    DeviceName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DeviceDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    ShowroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devicesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_devicesList_dealersList_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_devicesList_showroomsList_ShowroomId",
                        column: x => x.ShowroomId,
                        principalTable: "showroomsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_devicesList_DealerId",
                table: "devicesList",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_devicesList_ShowroomId",
                table: "devicesList",
                column: "ShowroomId");

            migrationBuilder.CreateIndex(
                name: "IX_showroomsList_DealerId",
                table: "showroomsList",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_variantList_CarModelId",
                table: "variantList",
                column: "CarModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicationImagesList");

            migrationBuilder.DropTable(
                name: "devicesList");

            migrationBuilder.DropTable(
                name: "extrasList");

            migrationBuilder.DropTable(
                name: "feedbackQuestionsList");

            migrationBuilder.DropTable(
                name: "healthCardList");

            migrationBuilder.DropTable(
                name: "insideInventoryList");

            migrationBuilder.DropTable(
                name: "interactiveCheckSheetsList");

            migrationBuilder.DropTable(
                name: "serviceProductList");

            migrationBuilder.DropTable(
                name: "settingsList");

            migrationBuilder.DropTable(
                name: "usersList");

            migrationBuilder.DropTable(
                name: "variantList");

            migrationBuilder.DropTable(
                name: "showroomsList");

            migrationBuilder.DropTable(
                name: "carModelList");

            migrationBuilder.DropTable(
                name: "dealersList");
        }
    }
}
