using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SkillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_TeacherDetails_TeacherDetailId",
                table: "TeacherSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSkills",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "TeacherSkills");

            migrationBuilder.RenameTable(
                name: "TeacherSkills",
                newName: "TeacherSkill");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkills_TeacherDetailId",
                table: "TeacherSkill",
                newName: "IX_TeacherSkill_TeacherDetailId");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "TeacherSkill",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSkill",
                table: "TeacherSkill",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkill_SkillId",
                table: "TeacherSkill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkill_Skill_SkillId",
                table: "TeacherSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkill_TeacherDetails_TeacherDetailId",
                table: "TeacherSkill",
                column: "TeacherDetailId",
                principalTable: "TeacherDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkill_Skill_SkillId",
                table: "TeacherSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkill_TeacherDetails_TeacherDetailId",
                table: "TeacherSkill");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSkill",
                table: "TeacherSkill");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSkill_SkillId",
                table: "TeacherSkill");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "TeacherSkill");

            migrationBuilder.RenameTable(
                name: "TeacherSkill",
                newName: "TeacherSkills");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkill_TeacherDetailId",
                table: "TeacherSkills",
                newName: "IX_TeacherSkills_TeacherDetailId");

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "TeacherSkills",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSkills",
                table: "TeacherSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_TeacherDetails_TeacherDetailId",
                table: "TeacherSkills",
                column: "TeacherDetailId",
                principalTable: "TeacherDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
