using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class newbooleancolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("37ea840d-d831-43fd-b3cb-fc85472b7bfa"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("45810299-2496-41f2-bb01-2b8e8cc4b754"));

            migrationBuilder.DeleteData(
                table: "BloodBankTable",
                keyColumn: "Id",
                keyValue: new Guid("dc26bbd4-ddb8-4cbd-93d6-bd5887e7041d"));

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "BloodBankTable",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "BloodBankTable");

            migrationBuilder.InsertData(
                table: "BloodBankTable",
                columns: new[] { "Id", "Apikey", "Email", "Password", "Path", "Username" },
                values: new object[,]
                {
                    { new Guid("dc26bbd4-ddb8-4cbd-93d6-bd5887e7041d"), "efwfe", "andykesic123@gmail.com", "edhb", null, "101A" },
                    { new Guid("37ea840d-d831-43fd-b3cb-fc85472b7bfa"), "dqad", "andykesic123@gmail.com", "fewsfd", null, "101A" },
                    { new Guid("45810299-2496-41f2-bb01-2b8e8cc4b754"), "ads", "andykesic123@gmail.com", "fcsde", null, "101A" }
                });
        }
    }
}
