using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CourseDetailUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseFeatures_CourseDetailId",
                table: "CourseFeatures");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFeatures_CourseDetailId",
                table: "CourseFeatures",
                column: "CourseDetailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseFeatures_CourseDetailId",
                table: "CourseFeatures");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFeatures_CourseDetailId",
                table: "CourseFeatures",
                column: "CourseDetailId");
        }
    }
}
