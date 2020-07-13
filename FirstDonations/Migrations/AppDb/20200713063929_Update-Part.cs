using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDonations.Migrations.AppDb
{
    public partial class UpdatePart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ApplicationUser_OwnerTeamId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_OwnerTeamId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "OwnerTeamId",
                table: "Parts");

            migrationBuilder.AddColumn<string>(
                name: "OwnerTeamIdId",
                table: "Parts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_OwnerTeamIdId",
                table: "Parts",
                column: "OwnerTeamIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ApplicationUser_OwnerTeamIdId",
                table: "Parts",
                column: "OwnerTeamIdId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ApplicationUser_OwnerTeamIdId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_OwnerTeamIdId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "OwnerTeamIdId",
                table: "Parts");

            migrationBuilder.AddColumn<string>(
                name: "OwnerTeamId",
                table: "Parts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_OwnerTeamId",
                table: "Parts",
                column: "OwnerTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ApplicationUser_OwnerTeamId",
                table: "Parts",
                column: "OwnerTeamId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
