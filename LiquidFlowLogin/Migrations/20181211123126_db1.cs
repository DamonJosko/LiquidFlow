using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquidFlowLogin.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "CountyStates",
                columns: table => new
                {
                    CountyStateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountyName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyStates", x => x.CountyStateID);
                });

            migrationBuilder.CreateTable(
                name: "FirstNames",
                columns: table => new
                {
                    FirstNameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstNames", x => x.FirstNameID);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    FuelTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FuelTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.FuelTypeID);
                });

            migrationBuilder.CreateTable(
                name: "LastNames",
                columns: table => new
                {
                    LastNameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastNames", x => x.LastNameID);
                });

            migrationBuilder.CreateTable(
                name: "Mixtures",
                columns: table => new
                {
                    MixtureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MixtureRatio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mixtures", x => x.MixtureID);
                });

            migrationBuilder.CreateTable(
                name: "RocketNames",
                columns: table => new
                {
                    RocketNameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RocketNames", x => x.RocketNameID);
                });

            migrationBuilder.CreateTable(
                name: "RocketOxidizers",
                columns: table => new
                {
                    RocketOxidizerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OxidizerName = table.Column<string>(nullable: true),
                    OxidizerAmount = table.Column<decimal>(nullable: false),
                    OxidizerPrice = table.Column<decimal>(nullable: false),
                    BuyCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RocketOxidizers", x => x.RocketOxidizerID);
                });

            migrationBuilder.CreateTable(
                name: "SafetyRecords",
                columns: table => new
                {
                    SafetyRecordID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SafetyRecordDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyRecords", x => x.SafetyRecordID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "StreetNames",
                columns: table => new
                {
                    StreetNameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StrName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetNames", x => x.StreetNameID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierNames",
                columns: table => new
                {
                    SupplierNameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierNames", x => x.SupplierNameID);
                });

            migrationBuilder.CreateTable(
                name: "ZIPs",
                columns: table => new
                {
                    ZIPID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZIPCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZIPs", x => x.ZIPID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RocketFuels",
                columns: table => new
                {
                    RocketFuelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FuelName = table.Column<string>(nullable: true),
                    FuelTypeID = table.Column<int>(nullable: false),
                    FuelAmount = table.Column<decimal>(nullable: false),
                    FuelPrice = table.Column<decimal>(nullable: false),
                    BuyCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RocketFuels", x => x.RocketFuelID);
                    table.ForeignKey(
                        name: "FK_RocketFuels_FuelTypes_FuelTypeID",
                        column: x => x.FuelTypeID,
                        principalTable: "FuelTypes",
                        principalColumn: "FuelTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMemebers",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstNameID = table.Column<int>(nullable: false),
                    LastNameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMemebers", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_StaffMemebers_FirstNames_FirstNameID",
                        column: x => x.FirstNameID,
                        principalTable: "FirstNames",
                        principalColumn: "FirstNameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffMemebers_LastNames_LastNameID",
                        column: x => x.LastNameID,
                        principalTable: "LastNames",
                        principalColumn: "LastNameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryVehicles",
                columns: table => new
                {
                    DeliveryVehicleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleRegistration = table.Column<string>(nullable: true),
                    StatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryVehicles", x => x.DeliveryVehicleID);
                    table.ForeignKey(
                        name: "FK_DeliveryVehicles_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HouseNumber = table.Column<int>(nullable: false),
                    StreetNameID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    CountyStateID = table.Column<int>(nullable: false),
                    ZIPID = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_CountyStates_CountyStateID",
                        column: x => x.CountyStateID,
                        principalTable: "CountyStates",
                        principalColumn: "CountyStateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_StreetNames_StreetNameID",
                        column: x => x.StreetNameID,
                        principalTable: "StreetNames",
                        principalColumn: "StreetNameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_ZIPs_ZIPID",
                        column: x => x.ZIPID,
                        principalTable: "ZIPs",
                        principalColumn: "ZIPID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RocketPropellants",
                columns: table => new
                {
                    RocketPropellantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RocketFuelID = table.Column<int>(nullable: false),
                    RocketOxidizerID = table.Column<int>(nullable: false),
                    MixtureID = table.Column<int>(nullable: false),
                    SupplierNameID = table.Column<int>(nullable: false),
                    SafetyRecordID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RocketPropellants", x => x.RocketPropellantID);
                    table.ForeignKey(
                        name: "FK_RocketPropellants_Mixtures_MixtureID",
                        column: x => x.MixtureID,
                        principalTable: "Mixtures",
                        principalColumn: "MixtureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RocketPropellants_RocketFuels_RocketFuelID",
                        column: x => x.RocketFuelID,
                        principalTable: "RocketFuels",
                        principalColumn: "RocketFuelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RocketPropellants_RocketOxidizers_RocketOxidizerID",
                        column: x => x.RocketOxidizerID,
                        principalTable: "RocketOxidizers",
                        principalColumn: "RocketOxidizerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RocketPropellants_SafetyRecords_SafetyRecordID",
                        column: x => x.SafetyRecordID,
                        principalTable: "SafetyRecords",
                        principalColumn: "SafetyRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RocketPropellants_SupplierNames_SupplierNameID",
                        column: x => x.SupplierNameID,
                        principalTable: "SupplierNames",
                        principalColumn: "SupplierNameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalOrderCost = table.Column<decimal>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DeliveryVehicleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryVehicles_DeliveryVehicleID",
                        column: x => x.DeliveryVehicleID,
                        principalTable: "DeliveryVehicles",
                        principalColumn: "DeliveryVehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddresses",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresses", x => new { x.CompanyID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffAddresses",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAddresses", x => new { x.StaffID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_StaffAddresses_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffAddresses_StaffMemebers_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffMemebers",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rockets",
                columns: table => new
                {
                    RocketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RocketNameID = table.Column<int>(nullable: false),
                    RocketModel = table.Column<string>(nullable: true),
                    CompanyID = table.Column<int>(nullable: false),
                    RocketPropellantID = table.Column<int>(nullable: false),
                    PropellantMaxCapacity = table.Column<decimal>(nullable: false),
                    PropellantCurrentCapacity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rockets", x => x.RocketID);
                    table.ForeignKey(
                        name: "FK_Rockets_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rockets_RocketNames_RocketNameID",
                        column: x => x.RocketNameID,
                        principalTable: "RocketNames",
                        principalColumn: "RocketNameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rockets_RocketPropellants_RocketPropellantID",
                        column: x => x.RocketPropellantID,
                        principalTable: "RocketPropellants",
                        principalColumn: "RocketPropellantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRocketPropellants",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    RocketPropellantID = table.Column<int>(nullable: false),
                    OrderRocketPropellantAmount = table.Column<decimal>(nullable: false),
                    OrderRocketPropellantCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRocketPropellants", x => new { x.OrderID, x.RocketPropellantID });
                    table.ForeignKey(
                        name: "FK_OrderRocketPropellants_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRocketPropellants_RocketPropellants_RocketPropellantID",
                        column: x => x.RocketPropellantID,
                        principalTable: "RocketPropellants",
                        principalColumn: "RocketPropellantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityID",
                table: "Addresses",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryID",
                table: "Addresses",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountyStateID",
                table: "Addresses",
                column: "CountyStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetNameID",
                table: "Addresses",
                column: "StreetNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ZIPID",
                table: "Addresses",
                column: "ZIPID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_AddressID",
                table: "CompanyAddresses",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVehicles_StatusID",
                table: "DeliveryVehicles",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRocketPropellants_RocketPropellantID",
                table: "OrderRocketPropellants",
                column: "RocketPropellantID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryVehicleID",
                table: "Orders",
                column: "DeliveryVehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_RocketFuels_FuelTypeID",
                table: "RocketFuels",
                column: "FuelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RocketPropellants_MixtureID",
                table: "RocketPropellants",
                column: "MixtureID");

            migrationBuilder.CreateIndex(
                name: "IX_RocketPropellants_RocketFuelID",
                table: "RocketPropellants",
                column: "RocketFuelID");

            migrationBuilder.CreateIndex(
                name: "IX_RocketPropellants_RocketOxidizerID",
                table: "RocketPropellants",
                column: "RocketOxidizerID");

            migrationBuilder.CreateIndex(
                name: "IX_RocketPropellants_SafetyRecordID",
                table: "RocketPropellants",
                column: "SafetyRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_RocketPropellants_SupplierNameID",
                table: "RocketPropellants",
                column: "SupplierNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Rockets_CompanyID",
                table: "Rockets",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Rockets_RocketNameID",
                table: "Rockets",
                column: "RocketNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Rockets_RocketPropellantID",
                table: "Rockets",
                column: "RocketPropellantID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddresses_AddressID",
                table: "StaffAddresses",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMemebers_FirstNameID",
                table: "StaffMemebers",
                column: "FirstNameID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMemebers_LastNameID",
                table: "StaffMemebers",
                column: "LastNameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompanyAddresses");

            migrationBuilder.DropTable(
                name: "OrderRocketPropellants");

            migrationBuilder.DropTable(
                name: "Rockets");

            migrationBuilder.DropTable(
                name: "StaffAddresses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "RocketNames");

            migrationBuilder.DropTable(
                name: "RocketPropellants");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "StaffMemebers");

            migrationBuilder.DropTable(
                name: "DeliveryVehicles");

            migrationBuilder.DropTable(
                name: "Mixtures");

            migrationBuilder.DropTable(
                name: "RocketFuels");

            migrationBuilder.DropTable(
                name: "RocketOxidizers");

            migrationBuilder.DropTable(
                name: "SafetyRecords");

            migrationBuilder.DropTable(
                name: "SupplierNames");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CountyStates");

            migrationBuilder.DropTable(
                name: "StreetNames");

            migrationBuilder.DropTable(
                name: "ZIPs");

            migrationBuilder.DropTable(
                name: "FirstNames");

            migrationBuilder.DropTable(
                name: "LastNames");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "FuelTypes");
        }
    }
}
