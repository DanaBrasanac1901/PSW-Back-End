using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class consiliums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           

            migrationBuilder.CreateTable(
                name: "Consiliums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Specialties = table.Column<string>(type: "text", nullable: true),
                    DoctorIds = table.Column<string>(type: "text", nullable: true),
                    FromTo = table.Column<DateTime>(type: "jsonb", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consiliums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsiliumAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    ConsiliumId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiliumAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsiliumAppointments_Consiliums_ConsiliumId",
                        column: x => x.ConsiliumId,
                        principalTable: "Consiliums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsiliumAppointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumAppointments_ConsiliumId",
                table: "ConsiliumAppointments",
                column: "ConsiliumId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumAppointments_DoctorId",
                table: "ConsiliumAppointments",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsiliumAppointments");

            migrationBuilder.DropTable(
                name: "Consiliums");

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Doctors");

            migrationBuilder.InsertData(
                table: "BloodConsumptionRecords",
                columns: new[] { "Id", "Amount", "CreatedAt", "DoctorId", "Reason", "SourceBank", "Type" },
                values: new object[] { 1, 2.0, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOC1", "needed for surgery", new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 0 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Quantity", "RoomId", "Type" },
                values: new object[] { "1", 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "HospitalBlood",
                columns: new[] { "Id", "Amount", "SourceBank", "Type" },
                values: new object[,]
                {
                    { 4, 10.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 3 },
                    { 1, 54.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 0 },
                    { 5, 23.0, new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), 0 },
                    { 7, 24.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), 0 },
                    { 3, 15.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 2 },
                    { 9, 34.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), 2 },
                    { 2, 30.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 1 },
                    { 6, 40.0, new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), 1 },
                    { 8, 10.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), 1 }
                });

            migrationBuilder.InsertData(
                table: "InpatientTreatmentRecords",
                columns: new[] { "Id", "AdmissionDate", "AdmissionReason", "BedID", "DischargeDate", "DischargeReason", "DoctorID", "PatientID", "RoomID", "Status", "Therapy" },
                values: new object[] { "1", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "bolesnik", "1", new DateTime(22, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "1", "1", "1", true, "nista" });
        }
    }
}
