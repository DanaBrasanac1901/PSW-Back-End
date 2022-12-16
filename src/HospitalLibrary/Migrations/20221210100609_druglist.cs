using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class druglist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugsList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugsList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DrugsList",
                columns: new[] { "Id", "CompanyName", "Name" },
                values: new object[,]
                {
                    { "aspirin", "Galenika", "Aspirin" },
                    { "brufen", "Galenika", "Brufen" },
                    { "ginko", "Galenika", "Ginko" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugsList");
        }
    }
}
