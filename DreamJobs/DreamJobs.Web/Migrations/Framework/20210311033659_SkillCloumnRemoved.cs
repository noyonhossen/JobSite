using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamJobs.Web.Migrations.Framework
{
    public partial class SkillCloumnRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsRequired",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SkillsRequired",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
