using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateHeaderTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeaderFooterId",
                table: "SocialMedias",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HeaderFooters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderFooters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_HeaderFooterId",
                table: "SocialMedias",
                column: "HeaderFooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_HeaderFooters_HeaderFooterId",
                table: "SocialMedias",
                column: "HeaderFooterId",
                principalTable: "HeaderFooters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_HeaderFooters_HeaderFooterId",
                table: "SocialMedias");

            migrationBuilder.DropTable(
                name: "HeaderFooters");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_HeaderFooterId",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "HeaderFooterId",
                table: "SocialMedias");
        }
    }
}
