using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherSimples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(maxLength: 30, nullable: false),
                    Profession = table.Column<string>(maxLength: 25, nullable: false),
                    IsSimple = table.Column<bool>(nullable: false, defaultValue: false),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false, defaultValue:DateTime.UtcNow)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSimples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: false),
                    Icon = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    TeacherSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                        column: x => x.TeacherSimpleId,
                        principalTable: "TeacherSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutContent = table.Column<string>(nullable: false),
                    Degree = table.Column<string>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Hobbies = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: false),
                    Mail = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Skype = table.Column<string>(nullable: true),
                    Language = table.Column<int>(nullable: false),
                    Design = table.Column<int>(nullable: false),
                    TeamLeader = table.Column<int>(nullable: false),
                    Innovation = table.Column<int>(nullable: false),
                    Development = table.Column<int>(nullable: false),
                    Comunication = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false,defaultValue:DateTime.UtcNow),
                    TeacherSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherDetails_TeacherSimples_TeacherSimpleId",
                        column: x => x.TeacherSimpleId,
                        principalTable: "TeacherSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_TeacherSimpleId",
                table: "SocialMedias",
                column: "TeacherSimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDetails_TeacherSimpleId",
                table: "TeacherDetails",
                column: "TeacherSimpleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "TeacherDetails");

            migrationBuilder.DropTable(
                name: "TeacherSimples");
        }
    }
}
