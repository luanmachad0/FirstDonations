using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDonations.Migrations.AppDb
{
    public partial class UpdateDonationPartModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonatorTeamId",
                table: "Donations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "DonatorTeamId",
                table: "Donations");
        }
    }
}
