using Microsoft.EntityFrameworkCore.Migrations;

namespace DbsCard.Migrations
{
    public partial class AddedImgFrUrlToCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardImgFr",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardImgFr",
                table: "Cards");
        }
    }
}
