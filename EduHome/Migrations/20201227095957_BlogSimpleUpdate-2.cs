using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class BlogSimpleUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogDetails_BlogDetailId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogDetailId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogDetailId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "BlogSimpleId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogSimpleId",
                table: "Comments",
                column: "BlogSimpleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogSimples_BlogSimpleId",
                table: "Comments",
                column: "BlogSimpleId",
                principalTable: "BlogSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogSimples_BlogSimpleId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogSimpleId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogSimpleId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "BlogDetailId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogDetailId",
                table: "Comments",
                column: "BlogDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogDetails_BlogDetailId",
                table: "Comments",
                column: "BlogDetailId",
                principalTable: "BlogDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
