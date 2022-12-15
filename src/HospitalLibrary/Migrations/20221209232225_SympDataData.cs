using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class SympDataData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SymptomList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SymptomList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "Glavobolja", "Glavobolja" },
                    { "Kijavica", "Kijavica" },
                    { "Dijareja", "Dijareja" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SymptomList");
        }
    }
}
