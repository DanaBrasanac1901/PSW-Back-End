using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Report;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DrugPrescriptionId = table.Column<string>(type: "text", nullable: true),
                    Drug = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugPrescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Drugs = table.Column<ICollection<Drug>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugPrescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    ReportDescription = table.Column<string>(type: "text", nullable: true),
                    Symptoms = table.Column<ICollection<Symptom>>(type: "jsonb", nullable: true),
                    DrugPrescriptionId = table.Column<string>(type: "text", nullable: true),
                    DayAndTimeOfMaking = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymptomLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReportId = table.Column<string>(type: "text", nullable: true),
                    Symptom = table.Column<string>(type: "text", nullable: true),
                    Severity = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugLists");

            migrationBuilder.DropTable(
                name: "DrugPrescriptions");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SymptomLists");

            migrationBuilder.DropTable(
                name: "Symptoms");
        }
    }
}
