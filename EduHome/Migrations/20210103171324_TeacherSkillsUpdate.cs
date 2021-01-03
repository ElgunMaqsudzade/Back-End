using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class TeacherSkillsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_TeacherDetails_TeacherDetailId",
                table: "TeacherSkills");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSkills_TeacherDetailId",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "TeacherDetailId",
                table: "TeacherSkills");

            migrationBuilder.AddColumn<int>(
                name: "TeacherSimpleId",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkills_TeacherSimpleId",
                table: "TeacherSkills",
                column: "TeacherSimpleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_TeacherSimples_TeacherSimpleId",
                table: "TeacherSkills",
                column: "TeacherSimpleId",
                principalTable: "TeacherSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_TeacherSimples_TeacherSimpleId",
                table: "TeacherSkills");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSkills_TeacherSimpleId",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "TeacherSimpleId",
                table: "TeacherSkills");

            migrationBuilder.AddColumn<int>(
                name: "TeacherDetailId",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkills_TeacherDetailId",
                table: "TeacherSkills",
                column: "TeacherDetailId");

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
