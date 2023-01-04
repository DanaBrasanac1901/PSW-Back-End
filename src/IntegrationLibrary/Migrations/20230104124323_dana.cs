using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class dana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2022, 11, 24, 15, 49, 15, 6, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.DeleteData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("a60460fe-0d33-478d-93b3-45d424079e66"));

            migrationBuilder.CreateTable(
                name: "AdvertisementTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdvertisementTable",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "ad1" },
                    { 2, "ad2" },
                    { 3, "ad3" }
                });

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Timestamp", "Id", "Text" },
                values: new object[] { new DateTime(2023, 1, 4, 13, 43, 22, 881, DateTimeKind.Local).AddTicks(8630), new Guid("9343f870-5c5f-4556-9a89-0f30adcd9c4a"), "doniraj krv" });

            migrationBuilder.UpdateData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                columns: new[] { "ConfigurationDate", "LastReportGeneration", "Period" },
                values: new object[] { new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("55510651-d36e-444d-95fb-871e0902cd7e"),
                columns: new[] { "ConfigurationDate", "LastReportGeneration" },
                values: new object[] { new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementTable");

            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2023, 1, 4, 13, 43, 22, 881, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Timestamp", "Id", "Text" },
                values: new object[] { new DateTime(2022, 11, 24, 15, 49, 15, 6, DateTimeKind.Local).AddTicks(8932), new Guid("bdf7764b-269f-4559-9ae5-86b6b021d4f7"), "doniraj krv" });

            migrationBuilder.UpdateData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                columns: new[] { "ConfigurationDate", "LastReportGeneration", "Period" },
                values: new object[] { new DateTime(2022, 11, 24, 15, 49, 15, 34, DateTimeKind.Local).AddTicks(349), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("55510651-d36e-444d-95fb-871e0902cd7e"),
                columns: new[] { "ConfigurationDate", "LastReportGeneration" },
                values: new object[] { new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "ReportTable",
                columns: new[] { "Id", "ConfigurationDate", "LastReportGeneration", "Period" },
                values: new object[] { new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), new DateTime(2022, 11, 24, 15, 49, 15, 33, DateTimeKind.Local).AddTicks(2779), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), 0 });
        }
    }
}
