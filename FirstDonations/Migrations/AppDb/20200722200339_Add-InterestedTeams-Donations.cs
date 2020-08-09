using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDonations.Migrations.AppDb
{
    public partial class AddInterestedTeamsDonations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InterestedTeams",
                table: "Donations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestedTeams",
                table: "Donations");
        }
    }
}
