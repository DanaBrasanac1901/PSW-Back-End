using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Patient;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class migracijaneka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:appointment_status", "scheduled,finished,cancelled")
                .Annotation("Npgsql:Enum:blood_type", "a,b,ab,o")
                .Annotation("Npgsql:Enum:gender", "male,female")
                .Annotation("Npgsql:Enum:specialty", "cardiologist,anesthesiologist,neurosurgeon");

            migrationBuilder.CreateTable(
                name: "BloodConsumptionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<BloodType>(type: "blood_type", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    SourceBank = table.Column<Guid>(type: "uuid", nullable: false)
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
                    Type = table.Column<BloodType>(type: "blood_type", nullable: false),
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
                    PatientName = table.Column<string>(type: "text", nullable: true),
                    PatientSurname = table.Column<string>(type: "text", nullable: true),
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
                    Type = table.Column<BloodType>(type: "blood_type", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    SourceBank = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBlood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InpatientTreatmentRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DoctorID = table.Column<string>(type: "text", nullable: true),
                    PatientID = table.Column<string>(type: "text", nullable: true),
                    RoomID = table.Column<string>(type: "text", nullable: true),
                    BedID = table.Column<string>(type: "text", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Therapy = table.Column<string>(type: "text", nullable: true),
                    AdmissionReason = table.Column<string>(type: "text", nullable: true),
                    DischargeReason = table.Column<string>(type: "text", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpatientTreatmentRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<Address>(type: "jsonb", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<Gender>(type: "gender", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    BloodType = table.Column<BloodType>(type: "blood_type", nullable: false),
                    Allergies = table.Column<List<string>>(type: "text[]", nullable: true),
                    DoctorID = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdByRole = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Specialty = table.Column<Specialty>(type: "specialty", nullable: false),
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
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Rooms_RoomId",
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
                    PatientId1 = table.Column<int>(type: "integer", nullable: true),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<AppointmentStatus>(type: "appointment_status", nullable: false)
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
                        name: "FK_Appointments_Patients_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "BloodConsumptionRecords",
                columns: new[] { "Id", "Amount", "CreatedAt", "DoctorId", "Reason", "SourceBank", "Type" },
                values: new object[] { 1, 2.0, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOC1", "needed for surgery", new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.A });

            migrationBuilder.InsertData(
                table: "HospitalBlood",
                columns: new[] { "Id", "Amount", "SourceBank", "Type" },
                values: new object[,]
                {
                    { 4, 10.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.O },
                    { 1, 54.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.A },
                    { 5, 23.0, new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), BloodType.A },
                    { 7, 24.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), BloodType.A },
                    { 3, 15.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.AB },
                    { 9, 34.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), BloodType.AB },
                    { 2, 30.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.B },
                    { 6, 40.0, new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), BloodType.B },
                    { 8, 10.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), BloodType.B }
                });

            migrationBuilder.InsertData(
                table: "InpatientTreatmentRecords",
                columns: new[] { "Id", "AdmissionDate", "AdmissionReason", "BedID", "DischargeDate", "DischargeReason", "DoctorID", "PatientID", "RoomID", "Status", "Therapy" },
                values: new object[] { "1", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "bolesnik", "1", new DateTime(22, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "1", "1", "1", true, "nista" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "Number" },
                values: new object[] { 1, 1, "1A" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Email", "IdByRole", "Name", "Password", "Role", "Surname", "Token" },
                values: new object[,]
                {
                    { 1, true, "manager", 1, "Milica", "AJMjUEYXE/EtKJlD2NfDblnM15ik0Wo547IgBuUFWyJtWRhj5PSBO/ttok4DT679oA==", "MANAGER", "Peric", null },
                    { 2, true, "doctor", 1, "Filip", "AKTyL6i1roIESl/br0aDrci1H15gFj0Wwede2GYJi0csDSUhrydNioQui0K3gfkJcA==", "DOCTOR", "Marinkovic", null }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Quantity", "RoomId", "Type" },
                values: new object[] { "1", 1, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_DoctorId",
                table: "VacationRequests",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BloodConsumptionRecords");

            migrationBuilder.DropTable(
                name: "BloodRequests");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HospitalBlood");

            migrationBuilder.DropTable(
                name: "InpatientTreatmentRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
