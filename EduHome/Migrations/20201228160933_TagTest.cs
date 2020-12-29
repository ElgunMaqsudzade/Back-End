using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class TagTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSimples_Professions_ProfessionId",
                table: "TeacherSimples");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionId",
                table: "TeacherSimples",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagBlogSimple",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(nullable: false),
                    BlogSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagBlogSimple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagBlogSimple_BlogSimples_BlogSimpleId",
                        column: x => x.BlogSimpleId,
                        principalTable: "BlogSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagBlogSimple_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagCourseSimple",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(nullable: false),
                    CourseSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCourseSimple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagCourseSimple_CourseSimples_CourseSimpleId",
                        column: x => x.CourseSimpleId,
                        principalTable: "CourseSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagCourseSimple_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagEventSimple",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(nullable: false),
                    EventSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEventSimple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagEventSimple_EventSimples_EventSimpleId",
                        column: x => x.EventSimpleId,
                        principalTable: "EventSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagEventSimple_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagBlogSimple_BlogSimpleId",
                table: "TagBlogSimple",
                column: "BlogSimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBlogSimple_TagId",
                table: "TagBlogSimple",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagCourseSimple_CourseSimpleId",
                table: "TagCourseSimple",
                column: "CourseSimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_TagCourseSimple_TagId",
                table: "TagCourseSimple",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagEventSimple_EventSimpleId",
                table: "TagEventSimple",
                column: "EventSimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_TagEventSimple_TagId",
                table: "TagEventSimple",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSimples_Professions_ProfessionId",
                table: "TeacherSimples",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSimples_Professions_ProfessionId",
                table: "TeacherSimples");

            migrationBuilder.DropTable(
                name: "TagBlogSimple");

            migrationBuilder.DropTable(
                name: "TagCourseSimple");

            migrationBuilder.DropTable(
                name: "TagEventSimple");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionId",
                table: "TeacherSimples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSimples_Professions_ProfessionId",
                table: "TeacherSimples",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
