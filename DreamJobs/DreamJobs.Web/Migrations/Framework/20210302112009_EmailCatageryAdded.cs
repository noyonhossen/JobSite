using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamJobs.Web.Migrations.Framework
{
    public partial class EmailCatageryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailForApply",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EmailForApply",
                table: "Jobs");
        }
    }
}
