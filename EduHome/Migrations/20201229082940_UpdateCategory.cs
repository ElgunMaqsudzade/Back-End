using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class UpdateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogSimples_Category_CategoryId",
                table: "BlogSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSimples_Category_CategoryId",
                table: "CourseSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSimples_Category_CategoryId",
                table: "EventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSimples_Category_CategoryId",
                table: "TeacherSimples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
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
                name: "FK_TeacherSimples_Categories_CategoryId",
                table: "TeacherSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_TeacherSimples_Categories_CategoryId",
                table: "TeacherSimples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogSimples_Category_CategoryId",
                table: "BlogSimples",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSimples_Category_CategoryId",
                table: "CourseSimples",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSimples_Category_CategoryId",
                table: "EventSimples",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSimples_Category_CategoryId",
                table: "TeacherSimples",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
