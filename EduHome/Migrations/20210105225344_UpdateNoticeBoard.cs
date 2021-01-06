using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class UpdateNoticeBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardTitle",
                table: "VideoTours");

            migrationBuilder.DropColumn(
                name: "VideoTitle",
                table: "VideoTours");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "VideoTours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "VideoTours");

            migrationBuilder.AddColumn<string>(
                name: "BoardTitle",
                table: "VideoTours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoTitle",
                table: "VideoTours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
