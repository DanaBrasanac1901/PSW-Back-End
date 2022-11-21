using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class Cetiri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, "holidays", "DOC1", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 2, "holidays", "DOC2", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 3, "holidays", "DOC3", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_DoctorId",
                table: "VacationRequests",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationRequests");
        }
    }
}
