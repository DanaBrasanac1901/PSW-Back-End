using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2022, 12, 13, 19, 5, 1, 520, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Timestamp", "Id", "Text" },
                values: new object[] { new DateTime(2022, 12, 13, 19, 38, 57, 1, DateTimeKind.Local).AddTicks(4447), new Guid("2a0f3e54-2fa0-449f-8962-9c9d83edd9c4"), "doniraj krv" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2022, 12, 13, 19, 38, 57, 1, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Timestamp", "Id", "Text" },
                values: new object[] { new DateTime(2022, 12, 13, 19, 5, 1, 520, DateTimeKind.Local).AddTicks(7500), new Guid("d3cc1eaf-759a-47d4-8061-fb42c1ecc8d0"), "doniraj krv" });
        }
    }
}
