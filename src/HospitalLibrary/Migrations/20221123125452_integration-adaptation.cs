using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class integrationadaptation : Migration
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
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    SourceBank = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodConsumptionRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBlood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    SourceBank = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBlood", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BloodConsumptionRecords",
                columns: new[] { "Id", "Amount", "CreatedAt", "DoctorId", "Reason", "SourceBank", "Type" },
                values: new object[] { 1, 2.0, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOC1", "needed for surgery", new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 0 });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodConsumptionRecords");

            migrationBuilder.DropTable(
                name: "HospitalBlood");
        }
    }
}
