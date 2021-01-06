using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class UpdateSliderImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgImage",
                table: "Sliders");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Sliders");

            migrationBuilder.AddColumn<string>(
                name: "BgImage",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
