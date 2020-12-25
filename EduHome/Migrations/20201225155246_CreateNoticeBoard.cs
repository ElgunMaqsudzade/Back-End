using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateNoticeBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Comunication",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "Development",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "TeamLeader",
                table: "TeacherDetails");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSimpleId",
                table: "SocialMedias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NoticeBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriptioon = table.Column<string>(nullable: false),
                    NoticeDate = table.Column<DateTime>(nullable: false,defaultValue:DateTime.UtcNow)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<string>(maxLength: 15, nullable: false),
                    Value = table.Column<int>(nullable: false),
                    TeacherDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSkills_TeacherDetails_TeacherDetailId",
                        column: x => x.TeacherDetailId,
                        principalTable: "TeacherDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoTours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoLink = table.Column<string>(nullable: false),
                    VideoTitle = table.Column<string>(nullable: false),
                    BoardTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTours", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkills_TeacherDetailId",
                table: "TeacherSkills",
                column: "TeacherDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias",
                column: "TeacherSimpleId",
                principalTable: "TeacherSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias");

            migrationBuilder.DropTable(
                name: "NoticeBoards");

            migrationBuilder.DropTable(
                name: "TeacherSkills");

            migrationBuilder.DropTable(
                name: "VideoTours");

            migrationBuilder.AddColumn<int>(
                name: "Comunication",
                table: "TeacherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design",
                table: "TeacherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Development",
                table: "TeacherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Innovation",
                table: "TeacherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "TeacherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeader",
                table: "TeacherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSimpleId",
                table: "SocialMedias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias",
                column: "TeacherSimpleId",
                principalTable: "TeacherSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
