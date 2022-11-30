using HospitalLibrary.Core.Report;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class ValjdaZadnja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DrugPrescriptionId = table.Column<string>(type: "text", nullable: true),
                    Drug = table.Column<Drug>(type: "jsonb", nullable: true),
                    Amount = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugLists");
        }
    }
}
