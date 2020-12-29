using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSimples_Categories_CategoryId",
                table: "TeacherSimples");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSimples_CategoryId",
                table: "TeacherSimples");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TeacherSimples");

            migrationBuilder.CreateTable(
                name: "HomeSliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    BgImage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeSliders");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TeacherSimples",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSimples_CategoryId",
                table: "TeacherSimples",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSimples_Categories_CategoryId",
                table: "TeacherSimples",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
