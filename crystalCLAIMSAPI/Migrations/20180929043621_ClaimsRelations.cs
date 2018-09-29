using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crystalCLAIMSAPI.Migrations
{
    public partial class ClaimsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CCT_HealthcareServices",
                table: "CCT_HealthcareServices");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CCT_HealthcareServices");

            migrationBuilder.DropColumn(
                name: "StandardDrug_Comment",
                table: "CCT_HealthcareServices");

            migrationBuilder.DropColumn(
                name: "StandardServiceProvided_Comment",
                table: "CCT_HealthcareServices");

            migrationBuilder.RenameTable(
                name: "CCT_HealthcareServices",
                newName: "CCT_StandardServiceProvided");

            migrationBuilder.AddColumn<int>(
                name: "MedicalPersonnelId",
                table: "CCT_HCPDoctors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CCT_StandardServiceProvided",
                table: "CCT_StandardServiceProvided",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CCT_StandardDiagnosis",
                columns: table => new
                {
                    ShortName = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_StandardDiagnosis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCT_StandardDrugs",
                columns: table => new
                {
                    ShortName = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_StandardDrugs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPServices_StandardServiceProvidedId",
                table: "CCT_HCPServices",
                column: "StandardServiceProvidedId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPDrugs_StandardDrugId",
                table: "CCT_HCPDrugs",
                column: "StandardDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPDoctors_MedicalPersonnelId",
                table: "CCT_HCPDoctors",
                column: "MedicalPersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPDiagnosis_StandardDiagnosisId",
                table: "CCT_HCPDiagnosis",
                column: "StandardDiagnosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_CCT_HCPDiagnosis_CCT_StandardDiagnosis_StandardDiagnosisId",
                table: "CCT_HCPDiagnosis",
                column: "StandardDiagnosisId",
                principalTable: "CCT_StandardDiagnosis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CCT_HCPDoctors_CCT_MedicalPersonnel_MedicalPersonnelId",
                table: "CCT_HCPDoctors",
                column: "MedicalPersonnelId",
                principalTable: "CCT_MedicalPersonnel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CCT_HCPDrugs_CCT_StandardDrugs_StandardDrugId",
                table: "CCT_HCPDrugs",
                column: "StandardDrugId",
                principalTable: "CCT_StandardDrugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CCT_HCPServices_CCT_StandardServiceProvided_StandardServiceProvidedId",
                table: "CCT_HCPServices",
                column: "StandardServiceProvidedId",
                principalTable: "CCT_StandardServiceProvided",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CCT_HCPDiagnosis_CCT_StandardDiagnosis_StandardDiagnosisId",
                table: "CCT_HCPDiagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_CCT_HCPDoctors_CCT_MedicalPersonnel_MedicalPersonnelId",
                table: "CCT_HCPDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_CCT_HCPDrugs_CCT_StandardDrugs_StandardDrugId",
                table: "CCT_HCPDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_CCT_HCPServices_CCT_StandardServiceProvided_StandardServiceProvidedId",
                table: "CCT_HCPServices");

            migrationBuilder.DropTable(
                name: "CCT_StandardDiagnosis");

            migrationBuilder.DropTable(
                name: "CCT_StandardDrugs");

            migrationBuilder.DropIndex(
                name: "IX_CCT_HCPServices_StandardServiceProvidedId",
                table: "CCT_HCPServices");

            migrationBuilder.DropIndex(
                name: "IX_CCT_HCPDrugs_StandardDrugId",
                table: "CCT_HCPDrugs");

            migrationBuilder.DropIndex(
                name: "IX_CCT_HCPDoctors_MedicalPersonnelId",
                table: "CCT_HCPDoctors");

            migrationBuilder.DropIndex(
                name: "IX_CCT_HCPDiagnosis_StandardDiagnosisId",
                table: "CCT_HCPDiagnosis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CCT_StandardServiceProvided",
                table: "CCT_StandardServiceProvided");

            migrationBuilder.DropColumn(
                name: "MedicalPersonnelId",
                table: "CCT_HCPDoctors");

            migrationBuilder.RenameTable(
                name: "CCT_StandardServiceProvided",
                newName: "CCT_HealthcareServices");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CCT_HealthcareServices",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StandardDrug_Comment",
                table: "CCT_HealthcareServices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardServiceProvided_Comment",
                table: "CCT_HealthcareServices",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CCT_HealthcareServices",
                table: "CCT_HealthcareServices",
                column: "Id");
        }
    }
}
