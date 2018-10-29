using Microsoft.EntityFrameworkCore.Migrations;

namespace crystalCLAIMSAPI.Migrations
{
    public partial class ClaimChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ipid",
                table: "CCT_IPUsers");

            migrationBuilder.DropColumn(
                name: "HCPId",
                table: "CCT_HCPUsers");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CCT_MedicalPersonnel",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceProviderId",
                table: "CCT_IPUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HealthcareProviderId",
                table: "CCT_HCPUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CCT_MedicalPersonnel");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceProviderId",
                table: "CCT_IPUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Ipid",
                table: "CCT_IPUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HealthcareProviderId",
                table: "CCT_HCPUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "HCPId",
                table: "CCT_HCPUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
