using Microsoft.EntityFrameworkCore.Migrations;

namespace crystalCLAIMSAPI.Migrations
{
    public partial class ClaimChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LineTotal",
                table: "CCT_ClaimServices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CCT_ClaimServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LineTotal",
                table: "CCT_ClaimDrugs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CCT_ClaimDrugs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LineTotal",
                table: "CCT_ClaimDiagnosis",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CCT_ClaimDiagnosis",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineTotal",
                table: "CCT_ClaimServices");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CCT_ClaimServices");

            migrationBuilder.DropColumn(
                name: "LineTotal",
                table: "CCT_ClaimDrugs");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CCT_ClaimDrugs");

            migrationBuilder.DropColumn(
                name: "LineTotal",
                table: "CCT_ClaimDiagnosis");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CCT_ClaimDiagnosis");
        }
    }
}
