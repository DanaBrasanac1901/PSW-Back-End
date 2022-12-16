using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class DPCorr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrugPrescriptionId",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "DrugPrescriptions",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "DrugPrescriptions");

            migrationBuilder.AddColumn<string>(
                name: "DrugPrescriptionId",
                table: "Reports",
                type: "text",
                nullable: true);
        }
    }
}
