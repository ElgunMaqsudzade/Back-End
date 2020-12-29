using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TeacherSimples",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "EventSimples",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CourseSimples",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BlogSimples",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSimples_CategoryId",
                table: "TeacherSimples",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSimples_CategoryId",
                table: "EventSimples",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSimples_CategoryId",
                table: "CourseSimples",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogSimples_CategoryId",
                table: "BlogSimples",
                column: "CategoryId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSimples_CategoryId",
                table: "TeacherSimples");

            migrationBuilder.DropIndex(
                name: "IX_EventSimples_CategoryId",
                table: "EventSimples");

            migrationBuilder.DropIndex(
                name: "IX_CourseSimples_CategoryId",
                table: "CourseSimples");

            migrationBuilder.DropIndex(
                name: "IX_BlogSimples_CategoryId",
                table: "BlogSimples");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TeacherSimples");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "EventSimples");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CourseSimples");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BlogSimples");
        }
    }
}
