using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SkillsTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogSimples_Categories_CategoryId",
                table: "BlogSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSimples_Categories_CategoryId",
                table: "CourseSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSimples_Categories_CategoryId",
                table: "EventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimples_EventSimples_EventSimpleId",
                table: "SpeakerEventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimples_Speakers_SpeakerId",
                table: "SpeakerEventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkill_Skill_SkillId",
                table: "TeacherSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkill_TeacherDetails_TeacherDetailId",
                table: "TeacherSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSkill",
                table: "TeacherSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "TeacherSkill",
                newName: "TeacherSkills");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkill_TeacherDetailId",
                table: "TeacherSkills",
                newName: "IX_TeacherSkills_TeacherDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkill_SkillId",
                table: "TeacherSkills",
                newName: "IX_TeacherSkills_SkillId");

            migrationBuilder.AlterColumn<int>(
                name: "SpeakerId",
                table: "SpeakerEventSimples",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventSimpleId",
                table: "SpeakerEventSimples",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "EventSimples",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "CourseSimples",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BlogSimples",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillValue",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSkills",
                table: "TeacherSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogSimples_Categories_CategoryId",
                table: "BlogSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSimples_Categories_CategoryId",
                table: "CourseSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSimples_Categories_CategoryId",
                table: "EventSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimples_EventSimples_EventSimpleId",
                table: "SpeakerEventSimples",
                column: "EventSimpleId",
                principalTable: "EventSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimples_Speakers_SpeakerId",
                table: "SpeakerEventSimples",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_TeacherDetails_TeacherDetailId",
                table: "TeacherSkills",
                column: "TeacherDetailId",
                principalTable: "TeacherDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogSimples_Categories_CategoryId",
                table: "BlogSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSimples_Categories_CategoryId",
                table: "CourseSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSimples_Categories_CategoryId",
                table: "EventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimples_EventSimples_EventSimpleId",
                table: "SpeakerEventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimples_Speakers_SpeakerId",
                table: "SpeakerEventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_TeacherDetails_TeacherDetailId",
                table: "TeacherSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSkills",
                table: "TeacherSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillValue",
                table: "TeacherSkills");

            migrationBuilder.RenameTable(
                name: "TeacherSkills",
                newName: "TeacherSkill");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkills_TeacherDetailId",
                table: "TeacherSkill",
                newName: "IX_TeacherSkill_TeacherDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkills_SkillId",
                table: "TeacherSkill",
                newName: "IX_TeacherSkill_SkillId");

            migrationBuilder.AlterColumn<int>(
                name: "SpeakerId",
                table: "SpeakerEventSimples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EventSimpleId",
                table: "SpeakerEventSimples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "EventSimples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "CourseSimples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BlogSimples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Skill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSkill",
                table: "TeacherSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogSimples_Categories_CategoryId",
                table: "BlogSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSimples_Categories_CategoryId",
                table: "CourseSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSimples_Categories_CategoryId",
                table: "EventSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimples_EventSimples_EventSimpleId",
                table: "SpeakerEventSimples",
                column: "EventSimpleId",
                principalTable: "EventSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimples_Speakers_SpeakerId",
                table: "SpeakerEventSimples",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
