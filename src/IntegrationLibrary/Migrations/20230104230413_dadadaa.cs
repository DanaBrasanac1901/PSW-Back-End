using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class dadadaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodBankTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Apikey = table.Column<string>(type: "text", nullable: true),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBankTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConfigurationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastReportGeneration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderOffers",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "integer", nullable: false),
                    BloodBankId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOffers", x => new { x.TenderId, x.BloodBankId });
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmountOfA = table.Column<double>(type: "double precision", nullable: false),
                    AmountOfB = table.Column<double>(type: "double precision", nullable: false),
                    AmountOfAB = table.Column<double>(type: "double precision", nullable: false),
                    AmountOfO = table.Column<double>(type: "double precision", nullable: false),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    Expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "ad1" },
                    { 2, "ad2" },
                    { 3, "ad3" }
                });

            migrationBuilder.InsertData(
                table: "BloodBankTable",
                columns: new[] { "Id", "Apikey", "Email", "IsConfirmed", "Password", "Path", "Username" },
                values: new object[,]
                {
                    { new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), "efwfe", "andykesic123@gmail.com", true, "edhb", null, "101A" },
                    { new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), "dqad", "andykesic123@gmail.com", true, "fewsfd", null, "101A" },
                    { new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), "ads", "andykesic123@gmail.com", true, "fcsde", null, "101A" }
                });

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Id", "Text", "Timestamp" },
                values: new object[] { new Guid("843f7177-9d68-431e-8a70-f97aed23410d"), "doniraj krv", new DateTime(2023, 1, 5, 0, 4, 12, 527, DateTimeKind.Local).AddTicks(5664) });

            migrationBuilder.InsertData(
                table: "ReportTable",
                columns: new[] { "Id", "ConfigurationDate", "LastReportGeneration", "Period" },
                values: new object[,]
                {
                    { new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "BloodBankTable");

            migrationBuilder.DropTable(
                name: "NewsTable");

            migrationBuilder.DropTable(
                name: "ReportTable");

            migrationBuilder.DropTable(
                name: "TenderOffers");

            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
