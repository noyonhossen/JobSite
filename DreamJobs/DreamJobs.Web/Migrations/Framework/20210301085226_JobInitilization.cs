using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamJobs.Web.Migrations.Framework
{
    public partial class JobInitilization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    JobContext = table.Column<string>(nullable: true),
                    JobResponsibilities = table.Column<string>(nullable: true),
                    Vacancy = table.Column<int>(nullable: false),
                    Salary = table.Column<string>(nullable: true),
                    JobLocation = table.Column<string>(nullable: true),
                    WorkPlace = table.Column<string>(nullable: true),
                    EducationRequired = table.Column<string>(nullable: true),
                    ExperienceRequirements = table.Column<string>(nullable: true),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    EmploymentStatus = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    AdditionalRequirements = table.Column<string>(nullable: true),
                    CompensationAndOtherBenefits = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    IsMaleApplicable = table.Column<bool>(nullable: false),
                    IsFemaleApplicable = table.Column<bool>(nullable: false),
                    IsOtherApplicable = table.Column<bool>(nullable: false),
                    SkillsRequired = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    JobId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => new { x.JobId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
