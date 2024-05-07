using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonutQueen.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DonutQueen");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "DonutQueen",
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
                schema: "DonutQueen",
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(nullable: false),
                    Straat = table.Column<string>(nullable: true),
                    Huisnummer = table.Column<int>(nullable: false),
                    Postocde = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true),
                    Geboortedatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donut",
                schema: "DonutQueen",
                columns: table => new
                {
                    DonutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Topping = table.Column<string>(nullable: false),
                    Glazuur = table.Column<string>(nullable: false),
                    Vulling = table.Column<string>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    IsVegan = table.Column<bool>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donut", x => x.DonutId);
                });

            migrationBuilder.CreateTable(
                name: "Leverancier",
                schema: "DonutQueen",
                columns: table => new
                {
                    LeverancierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeveranciersNaam = table.Column<string>(maxLength: 50, nullable: false),
                    VoornaamContact = table.Column<string>(nullable: true),
                    FamilienaamContact = table.Column<string>(nullable: true),
                    Emailadres = table.Column<string>(nullable: false),
                    Straat = table.Column<string>(maxLength: 100, nullable: false),
                    Huisnummer = table.Column<int>(nullable: false),
                    Postcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leverancier", x => x.LeverancierId);
                });

            migrationBuilder.CreateTable(
                name: "Winkel",
                schema: "DonutQueen",
                columns: table => new
                {
                    WinkelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Straat = table.Column<string>(maxLength: 100, nullable: false),
                    Nummer = table.Column<int>(nullable: false),
                    Gemeente = table.Column<string>(maxLength: 50, nullable: false),
                    Postcode = table.Column<int>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Telefoonnummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winkel", x => x.WinkelId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "DonutQueen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalSchema: "DonutQueen",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "DonutQueen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalSchema: "DonutQueen",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "DonutQueen",
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
                        principalSchema: "DonutQueen",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "DonutQueen",
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
                        principalSchema: "DonutQueen",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "DonutQueen",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "DonutQueen",
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
                        principalSchema: "DonutQueen",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeverancierDonut",
                schema: "DonutQueen",
                columns: table => new
                {
                    LeverancierDonutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeverancierId = table.Column<int>(nullable: false),
                    DonutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeverancierDonut", x => x.LeverancierDonutId);
                    table.ForeignKey(
                        name: "FK_LeverancierDonut_Donut_DonutId",
                        column: x => x.DonutId,
                        principalSchema: "DonutQueen",
                        principalTable: "Donut",
                        principalColumn: "DonutId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeverancierDonut_Leverancier_LeverancierId",
                        column: x => x.LeverancierId,
                        principalSchema: "DonutQueen",
                        principalTable: "Leverancier",
                        principalColumn: "LeverancierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WinkelDonut",
                schema: "DonutQueen",
                columns: table => new
                {
                    WinkelDonutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hoeveelheid = table.Column<int>(nullable: false),
                    Winkelid = table.Column<int>(nullable: false),
                    DonutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinkelDonut", x => x.WinkelDonutId);
                    table.ForeignKey(
                        name: "FK_WinkelDonut_Donut_DonutId",
                        column: x => x.DonutId,
                        principalSchema: "DonutQueen",
                        principalTable: "Donut",
                        principalColumn: "DonutId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WinkelDonut_Winkel_Winkelid",
                        column: x => x.Winkelid,
                        principalSchema: "DonutQueen",
                        principalTable: "Winkel",
                        principalColumn: "WinkelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "DonutQueen",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "DonutQueen",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "DonutQueen",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "DonutQueen",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "DonutQueen",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "DonutQueen",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "DonutQueen",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LeverancierDonut_DonutId",
                schema: "DonutQueen",
                table: "LeverancierDonut",
                column: "DonutId");

            migrationBuilder.CreateIndex(
                name: "IX_LeverancierDonut_LeverancierId",
                schema: "DonutQueen",
                table: "LeverancierDonut",
                column: "LeverancierId");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelDonut_DonutId",
                schema: "DonutQueen",
                table: "WinkelDonut",
                column: "DonutId");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelDonut_Winkelid",
                schema: "DonutQueen",
                table: "WinkelDonut",
                column: "Winkelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "LeverancierDonut",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "WinkelDonut",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "Leverancier",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "Donut",
                schema: "DonutQueen");

            migrationBuilder.DropTable(
                name: "Winkel",
                schema: "DonutQueen");
        }
    }
}
