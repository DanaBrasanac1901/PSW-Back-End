using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class testmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "APP1");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "APP2");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "APP3");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "DOC1");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "DOC2");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "DOC3");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "Number" },
                values: new object[,]
                {
                    { 1, 1, "101A" },
                    { 2, 2, "204" },
                    { 3, 3, "305B" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "EndWorkTime", "Name", "RoomId", "StartWorkTime", "Surname" },
                values: new object[,]
                {
                    { "DOC1", "imeprezime024@gmail.com", 15, "Ime", 1, 8, "Prezime" },
                    { "DOC2", "peraperic024@gmail.com", 15, "Pera", 2, 8, "Peric" },
                    { "DOC3", "djole1312@gmail.com", 15, "Djole", 3, 8, "Djokic" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DoctorId", "Duration", "PatientId", "RoomId", "Start", "Status" },
                values: new object[,]
                {
                    { "APP1", "DOC1", 0, "PAT1", 1, new DateTime(2022, 10, 25, 12, 20, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "APP2", "DOC2", 0, "PAT2", 2, new DateTime(2022, 10, 25, 12, 20, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "APP3", "DOC3", 0, "PAT3", 2, new DateTime(2022, 10, 25, 12, 20, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }
    }
}
