using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("220c2ea9-54fc-47ad-b231-f6efad8b020f"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("c85daacb-b094-4181-8311-2b9ddc865c85"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("d59911e4-5bbc-4054-a55e-cc6c05c789e7"));

            migrationBuilder.CreateTable(
                name: "NewsTable",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTable", x => x.Timestamp);
                });

            migrationBuilder.InsertData(
                table: "BloodBankTable",
                columns: new[] { "Id", "Apikey", "Email", "IsConfirmed", "Password", "Path", "Username" },
                values: new object[,]
                {
                    { new Guid("6ffb6d99-3c04-4e64-aa9e-b5d1ba628aed"), "efwfe", "andykesic123@gmail.com", true, "edhb", null, "101A" },
                    { new Guid("fb6e0f23-fc67-445b-98d5-88721a374528"), "dqad", "andykesic123@gmail.com", true, "fewsfd", null, "101A" },
                    { new Guid("12b6ea16-78eb-41b8-a5a2-b41fd5a9c82f"), "ads", "andykesic123@gmail.com", true, "fcsde", null, "101A" }
                });

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Timestamp", "Text" },
                values: new object[] { new DateTime(2022, 11, 11, 7, 42, 12, 114, DateTimeKind.Local).AddTicks(7079), "doniraj krv" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsTable");

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("12b6ea16-78eb-41b8-a5a2-b41fd5a9c82f"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("6ffb6d99-3c04-4e64-aa9e-b5d1ba628aed"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("fb6e0f23-fc67-445b-98d5-88721a374528"));

            migrationBuilder.InsertData(
                table: "BloodBankTable",
                columns: new[] { "Id", "Apikey", "Email", "IsConfirmed", "Password", "Path", "Username" },
                values: new object[,]
                {
                    { new Guid("220c2ea9-54fc-47ad-b231-f6efad8b020f"), "efwfe", "andykesic123@gmail.com", true, "edhb", null, "101A" },
                    { new Guid("c85daacb-b094-4181-8311-2b9ddc865c85"), "dqad", "andykesic123@gmail.com", true, "fewsfd", null, "101A" },
                    { new Guid("d59911e4-5bbc-4054-a55e-cc6c05c789e7"), "ads", "andykesic123@gmail.com", true, "fcsde", null, "101A" }
                });
        }
    }
}
