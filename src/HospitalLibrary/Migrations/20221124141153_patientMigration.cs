using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class patientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodConsumptionRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BloodRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HospitalBlood",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HospitalBlood",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HospitalBlood",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Feedbacks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientSurname",
                table: "Feedbacks",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    Allergies = table.Column<List<string>>(type: "text[]", nullable: true),
                    DoctorID = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "PatientSurname",
                table: "Feedbacks");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                values: new object[,]
                {
                    { 1, 150.0, 0 },
                    { 2, 130.0, 1 },
                    { 3, 100.0, 2 }
                });
        }
    }
}
