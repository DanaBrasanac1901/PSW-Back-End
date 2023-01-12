using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class addressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Patients",
                newName: "AddressJson");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AddressJson", "Age", "Allergies", "BloodType", "DoctorID", "Email", "Gender", "Jmbg", "Name", "Surname" },
                values: new object[] { 1, "{\"Street\":\"Bulevar Oslobodjenja\",\"StreetNumber\":\"80\",\"City\":\"Novi Sad\"}", 20, null, BloodType.B, null, "patient", Gender.FEMALE, "782847638", "Jelena", "Novakovic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "AddressJson",
                table: "Patients",
                newName: "Address");
        }
    }
}
