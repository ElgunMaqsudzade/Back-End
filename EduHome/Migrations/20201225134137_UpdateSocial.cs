using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class UpdateSocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialMedias");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSimpleId",
                table: "SocialMedias",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias",
                column: "TeacherSimpleId",
                principalTable: "TeacherSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSimpleId",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "SocialMedias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_TeacherSimples_TeacherSimpleId",
                table: "SocialMedias",
                column: "TeacherSimpleId",
                principalTable: "TeacherSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
