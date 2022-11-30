using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class AnjaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "IdByRole",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Patients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Jmbg",
                table: "Patients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId1",
                table: "Appointments",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IdByRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Jmbg",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Patients",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Patients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
