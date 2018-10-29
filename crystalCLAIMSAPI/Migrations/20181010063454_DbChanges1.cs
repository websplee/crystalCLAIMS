using Microsoft.EntityFrameworkCore.Migrations;

namespace crystalCLAIMSAPI.Migrations
{
    public partial class DbChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telehpone1",
                table: "CCT_PolicyHolders",
                newName: "Telephone1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telephone1",
                table: "CCT_PolicyHolders",
                newName: "Telehpone1");
        }
    }
}
