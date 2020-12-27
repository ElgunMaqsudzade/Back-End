using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SpeakerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimple_EventDetails_EventDetailId",
                table: "SpeakerEventSimple");

            migrationBuilder.DropIndex(
                name: "IX_SpeakerEventSimple_EventDetailId",
                table: "SpeakerEventSimple");

            migrationBuilder.DropColumn(
                name: "EventDetailId",
                table: "SpeakerEventSimple");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventDetailId",
                table: "SpeakerEventSimple",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerEventSimple_EventDetailId",
                table: "SpeakerEventSimple",
                column: "EventDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimple_EventDetails_EventDetailId",
                table: "SpeakerEventSimple",
                column: "EventDetailId",
                principalTable: "EventDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
