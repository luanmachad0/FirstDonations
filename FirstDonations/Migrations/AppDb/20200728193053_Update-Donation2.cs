using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDonations.Migrations.AppDb
{
    public partial class UpdateDonation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestedTeams",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "InterestedTeamId",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterestedTeamName",
                table: "Donations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestedTeamId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "InterestedTeamName",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "InterestedTeams",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
