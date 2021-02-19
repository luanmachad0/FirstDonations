using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDonations.Migrations.AppDb
{
    public partial class PartProfileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Parts_PartId",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Parts",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Parts_PartId",
                table: "Donations",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Parts_PartId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "Donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Parts_PartId",
                table: "Donations",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
