using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class TagTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagBlogSimple_BlogSimples_BlogSimpleId",
                table: "TagBlogSimple");

            migrationBuilder.DropForeignKey(
                name: "FK_TagBlogSimple_Tag_TagId",
                table: "TagBlogSimple");

            migrationBuilder.DropForeignKey(
                name: "FK_TagCourseSimple_CourseSimples_CourseSimpleId",
                table: "TagCourseSimple");

            migrationBuilder.DropForeignKey(
                name: "FK_TagCourseSimple_Tag_TagId",
                table: "TagCourseSimple");

            migrationBuilder.DropForeignKey(
                name: "FK_TagEventSimple_EventSimples_EventSimpleId",
                table: "TagEventSimple");

            migrationBuilder.DropForeignKey(
                name: "FK_TagEventSimple_Tag_TagId",
                table: "TagEventSimple");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagEventSimple",
                table: "TagEventSimple");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagCourseSimple",
                table: "TagCourseSimple");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagBlogSimple",
                table: "TagBlogSimple");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "TagEventSimple",
                newName: "TagEventSimples");

            migrationBuilder.RenameTable(
                name: "TagCourseSimple",
                newName: "TagCourseSimples");

            migrationBuilder.RenameTable(
                name: "TagBlogSimple",
                newName: "TagBlogSimples");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_TagEventSimple_TagId",
                table: "TagEventSimples",
                newName: "IX_TagEventSimples_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagEventSimple_EventSimpleId",
                table: "TagEventSimples",
                newName: "IX_TagEventSimples_EventSimpleId");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourseSimple_TagId",
                table: "TagCourseSimples",
                newName: "IX_TagCourseSimples_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourseSimple_CourseSimpleId",
                table: "TagCourseSimples",
                newName: "IX_TagCourseSimples_CourseSimpleId");

            migrationBuilder.RenameIndex(
                name: "IX_TagBlogSimple_TagId",
                table: "TagBlogSimples",
                newName: "IX_TagBlogSimples_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagBlogSimple_BlogSimpleId",
                table: "TagBlogSimples",
                newName: "IX_TagBlogSimples_BlogSimpleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagEventSimples",
                table: "TagEventSimples",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagCourseSimples",
                table: "TagCourseSimples",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagBlogSimples",
                table: "TagBlogSimples",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagBlogSimples_BlogSimples_BlogSimpleId",
                table: "TagBlogSimples",
                column: "BlogSimpleId",
                principalTable: "BlogSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagBlogSimples_Tags_TagId",
                table: "TagBlogSimples",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourseSimples_CourseSimples_CourseSimpleId",
                table: "TagCourseSimples",
                column: "CourseSimpleId",
                principalTable: "CourseSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourseSimples_Tags_TagId",
                table: "TagCourseSimples",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagEventSimples_EventSimples_EventSimpleId",
                table: "TagEventSimples",
                column: "EventSimpleId",
                principalTable: "EventSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagEventSimples_Tags_TagId",
                table: "TagEventSimples",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagBlogSimples_BlogSimples_BlogSimpleId",
                table: "TagBlogSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TagBlogSimples_Tags_TagId",
                table: "TagBlogSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TagCourseSimples_CourseSimples_CourseSimpleId",
                table: "TagCourseSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TagCourseSimples_Tags_TagId",
                table: "TagCourseSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TagEventSimples_EventSimples_EventSimpleId",
                table: "TagEventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TagEventSimples_Tags_TagId",
                table: "TagEventSimples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagEventSimples",
                table: "TagEventSimples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagCourseSimples",
                table: "TagCourseSimples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagBlogSimples",
                table: "TagBlogSimples");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "TagEventSimples",
                newName: "TagEventSimple");

            migrationBuilder.RenameTable(
                name: "TagCourseSimples",
                newName: "TagCourseSimple");

            migrationBuilder.RenameTable(
                name: "TagBlogSimples",
                newName: "TagBlogSimple");

            migrationBuilder.RenameIndex(
                name: "IX_TagEventSimples_TagId",
                table: "TagEventSimple",
                newName: "IX_TagEventSimple_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagEventSimples_EventSimpleId",
                table: "TagEventSimple",
                newName: "IX_TagEventSimple_EventSimpleId");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourseSimples_TagId",
                table: "TagCourseSimple",
                newName: "IX_TagCourseSimple_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourseSimples_CourseSimpleId",
                table: "TagCourseSimple",
                newName: "IX_TagCourseSimple_CourseSimpleId");

            migrationBuilder.RenameIndex(
                name: "IX_TagBlogSimples_TagId",
                table: "TagBlogSimple",
                newName: "IX_TagBlogSimple_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagBlogSimples_BlogSimpleId",
                table: "TagBlogSimple",
                newName: "IX_TagBlogSimple_BlogSimpleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagEventSimple",
                table: "TagEventSimple",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagCourseSimple",
                table: "TagCourseSimple",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagBlogSimple",
                table: "TagBlogSimple",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagBlogSimple_BlogSimples_BlogSimpleId",
                table: "TagBlogSimple",
                column: "BlogSimpleId",
                principalTable: "BlogSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagBlogSimple_Tag_TagId",
                table: "TagBlogSimple",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourseSimple_CourseSimples_CourseSimpleId",
                table: "TagCourseSimple",
                column: "CourseSimpleId",
                principalTable: "CourseSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourseSimple_Tag_TagId",
                table: "TagCourseSimple",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagEventSimple_EventSimples_EventSimpleId",
                table: "TagEventSimple",
                column: "EventSimpleId",
                principalTable: "EventSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagEventSimple_Tag_TagId",
                table: "TagEventSimple",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
