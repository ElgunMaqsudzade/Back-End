using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "TeacherSimples");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "TeacherSimples",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventSimpleId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventSimples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StartingTime = table.Column<DateTime>(nullable: false),
                    EndingTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false,defaultValue:DateTime.UtcNow)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSimples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutContent = table.Column<string>(nullable: false),
                    EventSimpleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDetails_EventSimples_EventSimpleId",
                        column: x => x.EventSimpleId,
                        principalTable: "EventSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false,defaultValue:DateTime.UtcNow),
                    ProfessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerEventSimple",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakerId = table.Column<int>(nullable: true),
                    EventSimpleId = table.Column<int>(nullable: true),
                    EventDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerEventSimple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakerEventSimple_EventDetails_EventDetailId",
                        column: x => x.EventDetailId,
                        principalTable: "EventDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeakerEventSimple_EventSimples_EventSimpleId",
                        column: x => x.EventSimpleId,
                        principalTable: "EventSimples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeakerEventSimple_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSimples_ProfessionId",
                table: "TeacherSimples",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventSimpleId",
                table: "Comments",
                column: "EventSimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventSimpleId",
                table: "EventDetails",
                column: "EventSimpleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerEventSimple_EventDetailId",
                table: "SpeakerEventSimple",
                column: "EventDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerEventSimple_EventSimpleId",
                table: "SpeakerEventSimple",
                column: "EventSimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerEventSimple_SpeakerId",
                table: "SpeakerEventSimple",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ProfessionId",
                table: "Speakers",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_EventSimples_EventSimpleId",
                table: "Comments",
                column: "EventSimpleId",
                principalTable: "EventSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSimples_Professions_ProfessionId",
                table: "TeacherSimples",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_EventSimples_EventSimpleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSimples_Professions_ProfessionId",
                table: "TeacherSimples");

            migrationBuilder.DropTable(
                name: "SpeakerEventSimple");

            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "EventSimples");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSimples_ProfessionId",
                table: "TeacherSimples");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EventSimpleId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "TeacherSimples");

            migrationBuilder.DropColumn(
                name: "EventSimpleId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "TeacherSimples",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
