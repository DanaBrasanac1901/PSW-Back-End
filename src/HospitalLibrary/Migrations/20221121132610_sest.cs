using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class sest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VacationRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VacationRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VacationRequests",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "Id", "Description", "DoctorId", "End", "RejectionReason", "Start", "Status", "Urgency" },
                values: new object[,]
                {
                    { 1, "holidays", "DOC1", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nista", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 2, "holidays", "DOC2", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nista", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 3, "holidays", "DOC3", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nista", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false }
                });
        }
    }
}
