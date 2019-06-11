using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbsCard.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SideCardId = table.Column<int>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    CardImg = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    CardSerie = table.Column<int>(nullable: false),
                    CardRarity = table.Column<int>(nullable: false),
                    CardType = table.Column<int>(nullable: false),
                    CardColor = table.Column<int>(nullable: false),
                    Power = table.Column<long>(nullable: false),
                    ComboCost = table.Column<string>(nullable: true),
                    ComboPower = table.Column<string>(nullable: true),
                    Character = table.Column<string>(nullable: true),
                    SpecialTrait = table.Column<string>(nullable: true),
                    Era = table.Column<string>(nullable: true),
                    TextMatchScore = table.Column<string>(nullable: true),
                    CardId = table.Column<string>(nullable: true),
                    BaseCardNumber = table.Column<string>(nullable: true),
                    SkillPlainText = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    OctgnId = table.Column<string>(nullable: true),
                    MaxAllowed = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    CardCount = table.Column<long>(nullable: false),
                    SideCardCount = table.Column<long>(nullable: false),
                    CostInt = table.Column<long>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    FullCardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Cards_SideCardId",
                        column: x => x.SideCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TcgData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<long>(nullable: false),
                    ProductUrl = table.Column<string>(nullable: true),
                    PartnerProductUrl = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    HighPrice = table.Column<double>(nullable: false),
                    MarketPrice = table.Column<double>(nullable: true),
                    MidPrice = table.Column<double>(nullable: false),
                    LowPrice = table.Column<double>(nullable: false),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcgData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TcgData_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SideCardId",
                table: "Cards",
                column: "SideCardId");

            migrationBuilder.CreateIndex(
                name: "IX_TcgData_CardId",
                table: "TcgData",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TcgData");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
