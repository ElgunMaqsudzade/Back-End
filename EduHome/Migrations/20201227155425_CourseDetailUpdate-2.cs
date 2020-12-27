using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CourseDetailUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CourseDetails_CourseDetailId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CourseDetailId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CourseDetailId",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "IsSimple",
                table: "CourseSimples",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CourseSimpleId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CourseSimpleId",
                table: "Comments",
                column: "CourseSimpleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CourseSimples_CourseSimpleId",
                table: "Comments",
                column: "CourseSimpleId",
                principalTable: "CourseSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CourseSimples_CourseSimpleId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CourseSimpleId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsSimple",
                table: "CourseSimples");

            migrationBuilder.DropColumn(
                name: "CourseSimpleId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CourseDetailId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CourseDetailId",
                table: "Comments",
                column: "CourseDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CourseDetails_CourseDetailId",
                table: "Comments",
                column: "CourseDetailId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
