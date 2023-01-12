using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class Pacijenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Active", "Age", "Allergies", "BloodType", "DoctorID", "Email", "Gender", "Jmbg", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, true, 34, null, BloodType.B, "DOC1", "Mail", Gender.MALE, "4564565656", "Prvi", "Prvic" },
                    { 2, true, 34, null, BloodType.A, "DOC1", "Mail2", Gender.MALE, "4564565656", "Drugi", "Drugic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
