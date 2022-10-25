using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    StartWorkTime = table.Column<int>(type: "integer", nullable: false),
                    EndWorkTime = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    PatientId = table.Column<string>(type: "text", nullable: true),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
