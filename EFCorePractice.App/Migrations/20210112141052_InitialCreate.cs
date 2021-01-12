using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCorePractice.App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AllianceId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alliances",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LeaderId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alliances_Players_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateAchieved = table.Column<DateTime>(type: "date", nullable: false),
                    MountId = table.Column<byte[]>(nullable: false),
                    PlayerId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heros_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BattleHero",
                columns: table => new
                {
                    HeroId = table.Column<byte[]>(nullable: false),
                    BattleId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleHero", x => new { x.HeroId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_BattleHero_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleHero_Heros_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HeroId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Heros_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mounts",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HeroId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mounts_Heros_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alliances_LeaderId",
                table: "Alliances",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleHero_BattleId",
                table: "BattleHero",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_HeroId",
                table: "Equipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_PlayerId",
                table: "Heros",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Mounts_HeroId",
                table: "Mounts",
                column: "HeroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_AllianceId",
                table: "Players",
                column: "AllianceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Alliances_AllianceId",
                table: "Players",
                column: "AllianceId",
                principalTable: "Alliances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alliances_Players_LeaderId",
                table: "Alliances");

            migrationBuilder.DropTable(
                name: "BattleHero");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Mounts");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Heros");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Alliances");
        }
    }
}
