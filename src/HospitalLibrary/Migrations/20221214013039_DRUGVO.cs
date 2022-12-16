using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class DRUGVO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Drugs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Drugs",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drugs",
                table: "Drugs",
                columns: new[] { "ReportId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Reports_ReportId",
                table: "Drugs",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Reports_ReportId",
                table: "Drugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drugs",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Drugs");
        }
    }
}
