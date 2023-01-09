using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class nn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsTable",
                table: "NewsTable");

            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Timestamp",
                keyValue: new DateTime(2022, 12, 13, 19, 38, 57, 1, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsTable",
                table: "NewsTable",
                column: "Id");

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Id", "Text", "Timestamp" },
                values: new object[] { new Guid("60eef45b-26ff-4b25-a473-f3707ea1deb4"), "doniraj krv", new DateTime(2022, 12, 13, 21, 36, 34, 54, DateTimeKind.Local).AddTicks(1615) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsTable",
                table: "NewsTable");

            migrationBuilder.DeleteData(
                table: "NewsTable",
                keyColumn: "Id",
                keyValue: new Guid("60eef45b-26ff-4b25-a473-f3707ea1deb4"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsTable",
                table: "NewsTable",
                column: "Timestamp");

            migrationBuilder.InsertData(
                table: "NewsTable",
                columns: new[] { "Timestamp", "Id", "Text" },
                values: new object[] { new DateTime(2022, 12, 13, 19, 38, 57, 1, DateTimeKind.Local).AddTicks(4447), new Guid("2a0f3e54-2fa0-449f-8962-9c9d83edd9c4"), "doniraj krv" });
        }
    }
}
