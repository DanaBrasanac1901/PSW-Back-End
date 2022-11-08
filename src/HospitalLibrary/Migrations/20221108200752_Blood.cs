using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class Blood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodConsumptionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodConsumptionRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    Due = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    VisibleToPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Anonymous = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBlood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBlood", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodConsumptionRecords");

            migrationBuilder.DropTable(
                name: "BloodRequests");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HospitalBlood");
        }
    }
}
