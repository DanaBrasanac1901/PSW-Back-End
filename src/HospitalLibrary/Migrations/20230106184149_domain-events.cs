using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class domainevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DomainEvent_Reports_ReportId",
                table: "DomainEvent");

            migrationBuilder.RenameTable(
                name: "DomainEvent",
                newName: "ReportCreationEvents");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "ReportCreationEvents",
                newName: "event_type");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ReportCreationEvents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportCreationEvents",
                table: "ReportCreationEvents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCreationEvents_ReportId",
                table: "ReportCreationEvents",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportCreationEvents_Reports_ReportId",
                table: "ReportCreationEvents",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportCreationEvents_Reports_ReportId",
                table: "ReportCreationEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportCreationEvents",
                table: "ReportCreationEvents");

            migrationBuilder.DropIndex(
                name: "IX_ReportCreationEvents_ReportId",
                table: "ReportCreationEvents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReportCreationEvents");

            migrationBuilder.RenameTable(
                name: "ReportCreationEvents",
                newName: "DomainEvent");

            migrationBuilder.RenameColumn(
                name: "event_type",
                table: "DomainEvent",
                newName: "Discriminator");

            migrationBuilder.AddForeignKey(
                name: "FK_DomainEvent_Reports_ReportId",
                table: "DomainEvent",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
