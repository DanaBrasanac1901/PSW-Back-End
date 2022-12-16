using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class blood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HospitalBlood",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "HospitalBlood",
                columns: new[] { "Id", "Amount", "SourceBank", "Type" },
                values: new object[] { 10, 58.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HospitalBlood",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "HospitalBlood",
                columns: new[] { "Id", "Amount", "SourceBank", "Type" },
                values: new object[] { 1, 54.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), 0 });
        }
    }
}
