using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodBank");

            migrationBuilder.CreateTable(
                name: "BloodBankTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Apikey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBankTable", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodBankTable");

            migrationBuilder.CreateTable(
                name: "BloodBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Apikey = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<int>(type: "integer", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBank", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BloodBank",
                columns: new[] { "Id", "Apikey", "Password", "Path", "Username" },
                values: new object[,]
                {
                    { 1, 34, 1, null, "101A" },
                    { 2, 34, 1, null, "101A" },
                    { 3, 34, 1, null, "101A" }
                });
        }
    }
}
