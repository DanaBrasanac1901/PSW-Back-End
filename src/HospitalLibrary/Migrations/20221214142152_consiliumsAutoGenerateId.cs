using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class consiliumsAutoGenerateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "FromTo",
                table: "Consiliums");

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Consiliums",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start",
                table: "Consiliums");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromTo",
                table: "Consiliums",
                type: "jsonb",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Consiliums",
                columns: new[] { "Id", "CreatedBy", "DoctorIds", "Duration", "Finished", "FromTo", "RoomId", "Specialties", "Topic" },
                values: new object[] { 1, "DOC1", "DOC1, DOC2", 45, false, new DateTime(2023, 3, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 999, "", "proba dal radi" });

            migrationBuilder.InsertData(
                table: "ConsiliumAppointments",
                columns: new[] { "Id", "ConsiliumId", "DoctorId" },
                values: new object[,]
                {
                    { 1, 1, "DOC1" },
                    { 2, 1, "DOC2" }
                });
        }
    }
}
