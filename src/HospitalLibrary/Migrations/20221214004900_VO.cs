using HospitalLibrary.Core.Report.Model;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class VO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Symptoms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Symptoms",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Symptoms",
                table: "Symptoms",
                columns: new[] { "ReportId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Reports_ReportId",
                table: "Symptoms",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Reports_ReportId",
                table: "Symptoms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Symptoms",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Symptoms");

            migrationBuilder.AddColumn<Symptom[]>(
                name: "Symptoms",
                table: "Reports",
                type: "jsonb",
                nullable: true);
        }
    }
}
