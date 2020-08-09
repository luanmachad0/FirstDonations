using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDonations.Migrations.AppDb
{
    public partial class UpdateDonation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePart",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamePart",
                table: "Donations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePart",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "NamePart",
                table: "Donations");
        }
    }
}
