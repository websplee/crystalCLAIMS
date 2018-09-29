using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crystalCLAIMSAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CCT_HealthcareServices",
                columns: table => new
                {
                    ShortName = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    StandardDrug_Comment = table.Column<string>(nullable: true),
                    StandardServiceProvided_Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_HealthcareServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCT_MedicalPersonnel",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Qualifications = table.Column<string>(nullable: true),
                    PracticingId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_MedicalPersonnel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCT_Provinces",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProvinceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCT_Districts",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictName = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_Districts_CCT_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "CCT_Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_HealthcareProviders",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProviderName = table.Column<string>(nullable: true),
                    ProviderCode = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    Telephone1 = table.Column<string>(nullable: true),
                    Telephone2 = table.Column<string>(nullable: true),
                    Telephone3 = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_HealthcareProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_HealthcareProviders_CCT_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "CCT_Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_InsuranceProviders",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProviderCode = table.Column<string>(nullable: true),
                    ProviderName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    Telephone1 = table.Column<string>(nullable: true),
                    Telephone2 = table.Column<string>(nullable: true),
                    Telephone3 = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_InsuranceProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_InsuranceProviders_CCT_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "CCT_Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_HCPDiagnosis",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HealthcareProviderId = table.Column<int>(nullable: false),
                    StandardDiagnosisId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_HCPDiagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_HCPDiagnosis_CCT_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "CCT_HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_HCPDoctors",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HealthcareProviderId = table.Column<int>(nullable: false),
                    HCPEmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_HCPDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_HCPDoctors_CCT_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "CCT_HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_HCPDrugs",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HealthcareProviderId = table.Column<int>(nullable: false),
                    StandardDrugId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_HCPDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_HCPDrugs_CCT_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "CCT_HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_HCPServices",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HealthcareProviderId = table.Column<int>(nullable: false),
                    StandardServiceProvidedId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_HCPServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_HCPServices_CCT_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "CCT_HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_HCPUsers",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AspNetUserId = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    HCPId = table.Column<int>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    HealthcareProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_HCPUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_HCPUsers_CCT_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "CCT_HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_IPUsers",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AspNetUserId = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Ipid = table.Column<int>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    InsuranceProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_IPUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_IPUsers_CCT_InsuranceProviders_InsuranceProviderId",
                        column: x => x.InsuranceProviderId,
                        principalTable: "CCT_InsuranceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_PolicyHolders",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyHolderName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Telehpone1 = table.Column<string>(nullable: true),
                    InsuranceProviderId = table.Column<int>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_PolicyHolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_PolicyHolders_CCT_InsuranceProviders_InsuranceProviderId",
                        column: x => x.InsuranceProviderId,
                        principalTable: "CCT_InsuranceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_Members",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyHolderId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    NationalId = table.Column<string>(nullable: true),
                    EmployeeNo = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    MemberSince = table.Column<DateTime>(nullable: true),
                    RelationshipType = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    AnnualLimit = table.Column<decimal>(nullable: true),
                    UtilizedTillDate = table.Column<decimal>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_Members_CCT_PolicyHolders_PolicyHolderId",
                        column: x => x.PolicyHolderId,
                        principalTable: "CCT_PolicyHolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_Claims",
                columns: table => new
                {
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    CheckerId = table.Column<int>(nullable: true),
                    MakerId = table.Column<int>(nullable: true),
                    RejectionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    HealthcareProviderId = table.Column<int>(nullable: true),
                    NameOfDoctor = table.Column<string>(nullable: true),
                    DoctorNumber = table.Column<string>(nullable: true),
                    ClaimInitiationDate = table.Column<DateTime>(nullable: true),
                    HospitalizationEvent = table.Column<string>(nullable: true),
                    BillAmount = table.Column<decimal>(nullable: true),
                    ApprovedAmount = table.Column<decimal>(nullable: true),
                    ClaimStatus = table.Column<int>(nullable: false),
                    ClaimComment = table.Column<string>(nullable: true),
                    HCPInputerId = table.Column<int>(nullable: true),
                    HCPApprovalStatus = table.Column<bool>(nullable: true),
                    HCPApproverId = table.Column<int>(nullable: true),
                    HCPApprovalDate = table.Column<DateTime>(nullable: true),
                    IPFirstApprovalStatus = table.Column<bool>(nullable: true),
                    IPFirstApprovalComment = table.Column<string>(nullable: true),
                    IPFirstApproverId = table.Column<int>(nullable: true),
                    IPFirstApproverChangeDate = table.Column<DateTime>(nullable: true),
                    IPSecondApprovalStatus = table.Column<bool>(nullable: true),
                    IPSecondApprovalComment = table.Column<string>(nullable: true),
                    IPSecondApproverId = table.Column<int>(nullable: true),
                    IPSecondApproverChangeDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_Claims_CCT_HCPUsers_HCPApproverId",
                        column: x => x.HCPApproverId,
                        principalTable: "CCT_HCPUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_Claims_CCT_HCPUsers_HCPInputerId",
                        column: x => x.HCPInputerId,
                        principalTable: "CCT_HCPUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_Claims_CCT_HealthcareProviders_HealthcareProviderId",
                        column: x => x.HealthcareProviderId,
                        principalTable: "CCT_HealthcareProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_Claims_CCT_IPUsers_IPFirstApproverId",
                        column: x => x.IPFirstApproverId,
                        principalTable: "CCT_IPUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_Claims_CCT_IPUsers_IPSecondApproverId",
                        column: x => x.IPSecondApproverId,
                        principalTable: "CCT_IPUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_Claims_CCT_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "CCT_Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_ClaimDiagnosis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimId = table.Column<int>(nullable: false),
                    HCPDiagnosisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_ClaimDiagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimDiagnosis_CCT_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "CCT_Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimDiagnosis_CCT_HCPDiagnosis_HCPDiagnosisId",
                        column: x => x.HCPDiagnosisId,
                        principalTable: "CCT_HCPDiagnosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_ClaimDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimId = table.Column<int>(nullable: false),
                    HCPDoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_ClaimDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimDoctors_CCT_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "CCT_Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimDoctors_CCT_HCPDoctors_HCPDoctorId",
                        column: x => x.HCPDoctorId,
                        principalTable: "CCT_HCPDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_ClaimDrugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimId = table.Column<int>(nullable: false),
                    HCPDrugId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_ClaimDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimDrugs_CCT_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "CCT_Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimDrugs_CCT_HCPDrugs_HCPDrugId",
                        column: x => x.HCPDrugId,
                        principalTable: "CCT_HCPDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCT_ClaimServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimId = table.Column<int>(nullable: false),
                    HCPServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCT_ClaimServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimServices_CCT_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "CCT_Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CCT_ClaimServices_CCT_HCPServices_HCPServiceId",
                        column: x => x.HCPServiceId,
                        principalTable: "CCT_HCPServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimDiagnosis_ClaimId",
                table: "CCT_ClaimDiagnosis",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimDiagnosis_HCPDiagnosisId",
                table: "CCT_ClaimDiagnosis",
                column: "HCPDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimDoctors_ClaimId",
                table: "CCT_ClaimDoctors",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimDoctors_HCPDoctorId",
                table: "CCT_ClaimDoctors",
                column: "HCPDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimDrugs_ClaimId",
                table: "CCT_ClaimDrugs",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimDrugs_HCPDrugId",
                table: "CCT_ClaimDrugs",
                column: "HCPDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Claims_HCPApproverId",
                table: "CCT_Claims",
                column: "HCPApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Claims_HCPInputerId",
                table: "CCT_Claims",
                column: "HCPInputerId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Claims_HealthcareProviderId",
                table: "CCT_Claims",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Claims_IPFirstApproverId",
                table: "CCT_Claims",
                column: "IPFirstApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Claims_IPSecondApproverId",
                table: "CCT_Claims",
                column: "IPSecondApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Claims_MemberId",
                table: "CCT_Claims",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimServices_ClaimId",
                table: "CCT_ClaimServices",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_ClaimServices_HCPServiceId",
                table: "CCT_ClaimServices",
                column: "HCPServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Districts_ProvinceId",
                table: "CCT_Districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPDiagnosis_HealthcareProviderId",
                table: "CCT_HCPDiagnosis",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPDoctors_HealthcareProviderId",
                table: "CCT_HCPDoctors",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPDrugs_HealthcareProviderId",
                table: "CCT_HCPDrugs",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPServices_HealthcareProviderId",
                table: "CCT_HCPServices",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HCPUsers_HealthcareProviderId",
                table: "CCT_HCPUsers",
                column: "HealthcareProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_HealthcareProviders_DistrictId",
                table: "CCT_HealthcareProviders",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_InsuranceProviders_DistrictId",
                table: "CCT_InsuranceProviders",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_IPUsers_InsuranceProviderId",
                table: "CCT_IPUsers",
                column: "InsuranceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_Members_PolicyHolderId",
                table: "CCT_Members",
                column: "PolicyHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_CCT_PolicyHolders_InsuranceProviderId",
                table: "CCT_PolicyHolders",
                column: "InsuranceProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CCT_ClaimDiagnosis");

            migrationBuilder.DropTable(
                name: "CCT_ClaimDoctors");

            migrationBuilder.DropTable(
                name: "CCT_ClaimDrugs");

            migrationBuilder.DropTable(
                name: "CCT_ClaimServices");

            migrationBuilder.DropTable(
                name: "CCT_HealthcareServices");

            migrationBuilder.DropTable(
                name: "CCT_MedicalPersonnel");

            migrationBuilder.DropTable(
                name: "CCT_HCPDiagnosis");

            migrationBuilder.DropTable(
                name: "CCT_HCPDoctors");

            migrationBuilder.DropTable(
                name: "CCT_HCPDrugs");

            migrationBuilder.DropTable(
                name: "CCT_Claims");

            migrationBuilder.DropTable(
                name: "CCT_HCPServices");

            migrationBuilder.DropTable(
                name: "CCT_HCPUsers");

            migrationBuilder.DropTable(
                name: "CCT_IPUsers");

            migrationBuilder.DropTable(
                name: "CCT_Members");

            migrationBuilder.DropTable(
                name: "CCT_HealthcareProviders");

            migrationBuilder.DropTable(
                name: "CCT_PolicyHolders");

            migrationBuilder.DropTable(
                name: "CCT_InsuranceProviders");

            migrationBuilder.DropTable(
                name: "CCT_Districts");

            migrationBuilder.DropTable(
                name: "CCT_Provinces");
        }
    }
}
