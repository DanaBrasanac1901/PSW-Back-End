using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class mkj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

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
                name: "BloodbankId",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "ReportTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTable",
                table: "ReportTable",
                column: "Id");

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
                columns: new[] { "Timestamp", "Id", "Text" },
                values: new object[] { new DateTime(2022, 11, 24, 15, 49, 15, 6, DateTimeKind.Local).AddTicks(8932), new Guid("bdf7764b-269f-4559-9ae5-86b6b021d4f7"), "doniraj krv" });

            migrationBuilder.InsertData(
                table: "ReportTable",
                columns: new[] { "Id", "ConfigurationDate", "LastReportGeneration", "Period" },
                values: new object[,]
                {
                    { new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), new DateTime(2022, 11, 24, 15, 49, 15, 33, DateTimeKind.Local).AddTicks(2779), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), new DateTime(2022, 11, 24, 15, 49, 15, 34, DateTimeKind.Local).AddTicks(349), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTable",
                table: "ReportTable");

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("2d4894b6-02e4-4288-a3d3-089489563190"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("55510651-d36e-444d-95fb-871e0902cd7e"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("a60460fe-0d33-478d-93b3-45d424079e66"));

            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2022, 11, 24, 15, 49, 15, 6, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.DeleteData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("2d4894b6-02e4-4288-a3d3-089489563190"));

            migrationBuilder.DeleteData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("55510651-d36e-444d-95fb-871e0902cd7e"));

            migrationBuilder.DeleteData(
                table: "ReportTable",
                keyColumn: "Id",
                keyValue: new Guid("a60460fe-0d33-478d-93b3-45d424079e66"));

            migrationBuilder.RenameTable(
                name: "ReportTable",
                newName: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "BloodbankId",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

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
    }
}
