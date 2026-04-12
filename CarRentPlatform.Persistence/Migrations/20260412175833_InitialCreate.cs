using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentPlatform.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleNameId = table.Column<int>(type: "int", nullable: false),
                    ModelPermissions = table.Column<int>(type: "int", nullable: false),
                    CarsPermissions = table.Column<int>(type: "int", nullable: false),
                    UserPermissions = table.Column<int>(type: "int", nullable: false),
                    SelfPermissions = table.Column<int>(type: "int", nullable: false),
                    RentalPeriodPermissions = table.Column<int>(type: "int", nullable: false),
                    RolePermissions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleNameId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarColor = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModels",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ModelSpecifications",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fuel = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeatsWithDriver = table.Column<int>(type: "int", nullable: false),
                    TrunkVoluem = table.Column<float>(type: "real", nullable: false),
                    TankCapacity = table.Column<float>(type: "real", nullable: false),
                    CityConsumptionPer100km = table.Column<float>(type: "real", nullable: false),
                    HighwayConsumptionPer100km = table.Column<float>(type: "real", nullable: false),
                    CityRangeKm = table.Column<float>(type: "real", nullable: false),
                    HighwayRangeKm = table.Column<float>(type: "real", nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    IsAutomaticTransmission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelSpecifications", x => x.ModelId);
                    table.CheckConstraint("CK_ModelSpecifications_CityConsumptionPer100km_Min", "[CityConsumptionPer100km] >= 0");
                    table.CheckConstraint("CK_ModelSpecifications_CityRangeKm_Min", "[CityRangeKm] >= 0");
                    table.CheckConstraint("CK_ModelSpecifications_HighwayConsumptionPer100km_Min", "[HighwayConsumptionPer100km] >= 0");
                    table.CheckConstraint("CK_ModelSpecifications_HighwayRangeKm_Min", "[HighwayRangeKm] >= 0");
                    table.CheckConstraint("CK_ModelSpecifications_NumberOfSeatsWithDriver_Min", "[NumberOfSeatsWithDriver] >= 1");
                    table.CheckConstraint("CK_ModelSpecifications_TankCapacity_Min", "[TankCapacity] >= 0");
                    table.CheckConstraint("CK_ModelSpecifications_TrunkVoluem_Min", "[TrunkVoluem] >= 0");
                    table.ForeignKey(
                        name: "FK_ModelSpecifications_CarModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModels",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleNameId = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleNameId",
                        column: x => x.RoleNameId,
                        principalTable: "Roles",
                        principalColumn: "RoleNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarPriceDatas",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PricePerDayBYN = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LateReturnPenaltyPerDayBYN = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPriceDatas", x => x.CarId);
                    table.CheckConstraint("CK_CarPriceData_LateReturnPenaltyPerDayBYN_Min", "[LateReturnPenaltyPerDayBYN] >= 0");
                    table.CheckConstraint("CK_CarPriceData_PricePerDayBYN_Min", "[PricePerDayBYN] >= 0");
                    table.ForeignKey(
                        name: "FK_CarPriceDatas_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarReservationDatas",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarReservationStatus = table.Column<int>(type: "int", nullable: false),
                    ServiceTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReservationDatas", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_CarReservationDatas_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConditions",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConditions", x => x.UserId);
                    table.CheckConstraint("CK_User_Rating_Range", "[Rating] >= 0 AND [Rating] <= 10");
                    table.ForeignKey(
                        name: "FK_UserConditions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDocumentsDatas",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverLicenseCategory = table.Column<int>(type: "int", nullable: false),
                    LicenseExpirationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocumentsDatas", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserDocumentsDatas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalPeriods",
                columns: table => new
                {
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodStatus = table.Column<int>(type: "int", nullable: false),
                    RentalPriceBYN = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPeriods", x => x.PeriodId);
                    table.CheckConstraint("CK_RentalPeriod_DateTimeStart_LessThan_DateTimeEnd", "[DateTimeStart] <= [DateTimeEnd]");
                    table.CheckConstraint("CK_RentalPeriod_RentalPriceBYN_Min", "[RentalPriceBYN] >= 0");
                    table.ForeignKey(
                        name: "FK_RentalPeriods_CarReservationDatas_CarId",
                        column: x => x.CarId,
                        principalTable: "CarReservationDatas",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalPeriods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleNameId", "CarsPermissions", "ModelPermissions", "RentalPeriodPermissions", "RolePermissions", "SelfPermissions", "UserPermissions" },
                values: new object[,]
                {
                    { 1, 2, 2, 2, 0, 6, 0 },
                    { 2, 15, 15, 15, 15, 15, 15 },
                    { 3, 2, 2, 2, 0, 6, 2 },
                    { 4, 2, 2, 15, 0, 6, 2 },
                    { 5, 15, 15, 15, 0, 6, 0 },
                    { 6, 0, 0, 0, 2, 6, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPeriods_CarId",
                table: "RentalPeriods",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPeriods_UserId",
                table: "RentalPeriods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Email",
                table: "UserAccounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_PhoneNumber",
                table: "UserAccounts",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleNameId",
                table: "Users",
                column: "RoleNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPriceDatas");

            migrationBuilder.DropTable(
                name: "ModelSpecifications");

            migrationBuilder.DropTable(
                name: "RentalPeriods");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserConditions");

            migrationBuilder.DropTable(
                name: "UserDocumentsDatas");

            migrationBuilder.DropTable(
                name: "CarReservationDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}
