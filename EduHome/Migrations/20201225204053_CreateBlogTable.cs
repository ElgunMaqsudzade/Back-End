using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "TeacherDetails");

            migrationBuilder.CreateTable(
                name: "BlogSimples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false,defaultValue:DateTime.UtcNow)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogSimples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutContent = table.Column<string>(nullable: false),
                    BlogSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogDetails_BlogSimples_BlogSimpleId",
                        column: x => x.BlogSimpleId,
                        principalTable: "BlogSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_BlogSimpleId",
                table: "BlogDetails",
                column: "BlogSimpleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogDetails");

            migrationBuilder.DropTable(
                name: "BlogSimples");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "TeacherDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "TeacherDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TeacherDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "TeacherDetails",
                type: "datetime2",
                nullable: true);
        }
    }
}
