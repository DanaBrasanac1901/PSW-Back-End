using HospitalLibrary.Core.Report;
using HospitalLibrary.Core.Report.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class WOLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugLists");

            migrationBuilder.DropTable(
                name: "SymptomLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Drug = table.Column<Drug>(type: "jsonb", nullable: true),
                    DrugPrescriptionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymptomLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReportId = table.Column<string>(type: "text", nullable: true),
                    Severity = table.Column<string>(type: "text", nullable: true),
                    Symptom = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomLists", x => x.Id);
                });
        }
    }
}
