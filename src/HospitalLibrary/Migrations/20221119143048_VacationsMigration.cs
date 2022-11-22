using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class VacationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    Allergies = table.Column<string>(type: "text", nullable: true),
                    DoctorID = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Urgency = table.Column<bool>(type: "boolean", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    RejectionReason = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "Id", "Description", "DoctorId", "End", "RejectionReason", "Start", "Status", "Urgency" },
                values: new object[,]
                {
                    { 1, "im tired nigga", "DOC1", new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 2, "certified nigga", "DOC1", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "aca lukas je narkoman", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_DoctorId",
                table: "VacationRequests",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.InsertData(
                table: "BloodConsumptionRecords",
                columns: new[] { "Id", "Amount", "CreatedAt", "DoctorId", "Reason", "Type" },
                values: new object[] { 1, 10.0, new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOC1", "need for surgery", 0 });

            migrationBuilder.InsertData(
                table: "BloodRequests",
                columns: new[] { "Id", "Amount", "DoctorId", "Due", "Reason", "Type" },
                values: new object[,]
                {
                    { 1, 100.0, "DOC1", new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "need for patient treatment", 0 },
                    { 2, 150.0, "DOC2", new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "need for patient treatment", 1 },
                    { 3, 150.0, "DOC1", new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "need for transfusion", 2 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "ID", "Anonymous", "Approved", "Date", "PatientId", "Text", "VisibleToPublic" },
                values: new object[,]
                {
                    { 1, false, false, new DateTime(2022, 8, 27, 8, 15, 0, 0, DateTimeKind.Unspecified), 1, "neki komentar", true },
                    { 2, false, false, new DateTime(2022, 9, 13, 14, 53, 0, 0, DateTimeKind.Unspecified), 2, "neki drugi komentar", true },
                    { 3, false, false, new DateTime(2022, 10, 10, 11, 22, 0, 0, DateTimeKind.Unspecified), 3, "neki treci komentar", true }
                });

            migrationBuilder.InsertData(
                table: "HospitalBlood",
                columns: new[] { "Id", "Amount", "Type" },
                values: new object[] { 1, 150.0, 0 });
        }
    }
}
