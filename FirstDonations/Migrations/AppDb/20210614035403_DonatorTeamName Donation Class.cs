using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDonations.Migrations.AppDb
{
    public partial class DonatorTeamNameDonationClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonatorTeamName",
                table: "Donations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonatorTeamName",
                table: "Donations");
        }
    }
}
