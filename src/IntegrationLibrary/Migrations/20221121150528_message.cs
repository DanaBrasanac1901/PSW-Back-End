using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2022, 11, 11, 7, 42, 12, 114, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "NewsTable",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodbankId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConfigurationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastReportGeneration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BloodBankTable",
                columns: new[] { "Id", "Apikey", "Email", "IsConfirmed", "Password", "Path", "Username" },
                values: new object[,]
                {
                    { new Guid("41021ad9-d16a-49b9-92e6-d75979ea375b"), "efwfe", "andykesic123@gmail.com", true, "edhb", null, "101A" },
                    { new Guid("e21cb335-f629-40fa-bcb0-a7f24f890279"), "dqad", "andykesic123@gmail.com", true, "fewsfd", null, "101A" },
                    { new Guid("581aab9d-809c-4a5c-94f3-74ffc2e4ce78"), "ads", "andykesic123@gmail.com", true, "fcsde", null, "101A" }
                });

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Timestamp", "Id", "Text" },
                values: new object[] { new DateTime(2022, 11, 21, 16, 5, 27, 508, DateTimeKind.Local).AddTicks(5446), new Guid("7b511c23-ed6e-4999-81a7-4e001474c4c2"), "doniraj krv" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("41021ad9-d16a-49b9-92e6-d75979ea375b"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("581aab9d-809c-4a5c-94f3-74ffc2e4ce78"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("e21cb335-f629-40fa-bcb0-a7f24f890279"));

            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2022, 11, 21, 16, 5, 27, 508, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NewsTable");

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
    }
}
