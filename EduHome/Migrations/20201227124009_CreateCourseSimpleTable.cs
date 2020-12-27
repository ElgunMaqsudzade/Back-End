using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateCourseSimpleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogSimples_BlogSimpleId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "BlogSimpleId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CourseDetailId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseSimples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    MainContent = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false,defaultValue: DateTime.UtcNow)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSimples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutCourse = table.Column<string>(nullable: false),
                    ApplyContent = table.Column<string>(nullable: false),
                    CertificationContent = table.Column<string>(nullable: false),
                    CourseSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDetails_CourseSimples_CourseSimpleId",
                        column: x => x.CourseSimpleId,
                        principalTable: "CourseSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingTime = table.Column<DateTime>(nullable: false),
                    CourseDuration = table.Column<int>(nullable: false),
                    ClassDuration = table.Column<int>(nullable: false),
                    SkillLevel = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    StudentCount = table.Column<int>(nullable: false),
                    Assesment = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    CourseDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFeatures_CourseDetails_CourseDetailId",
                        column: x => x.CourseDetailId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CourseDetailId",
                table: "Comments",
                column: "CourseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_CourseSimpleId",
                table: "CourseDetails",
                column: "CourseSimpleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseFeatures_CourseDetailId",
                table: "CourseFeatures",
                column: "CourseDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogSimples_BlogSimpleId",
                table: "Comments",
                column: "BlogSimpleId",
                principalTable: "BlogSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CourseDetails_CourseDetailId",
                table: "Comments",
                column: "CourseDetailId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogSimples_BlogSimpleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CourseDetails_CourseDetailId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CourseFeatures");

            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "CourseSimples");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CourseDetailId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CourseDetailId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "BlogSimpleId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogSimples_BlogSimpleId",
                table: "Comments",
                column: "BlogSimpleId",
                principalTable: "BlogSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
