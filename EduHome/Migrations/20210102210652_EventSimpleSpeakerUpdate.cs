using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class EventSimpleSpeakerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimple_EventSimples_EventSimpleId",
                table: "SpeakerEventSimple");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimple_Speakers_SpeakerId",
                table: "SpeakerEventSimple");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEventSimple",
                table: "SpeakerEventSimple");

            migrationBuilder.RenameTable(
                name: "SpeakerEventSimple",
                newName: "SpeakerEventSimples");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEventSimple_SpeakerId",
                table: "SpeakerEventSimples",
                newName: "IX_SpeakerEventSimples_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEventSimple_EventSimpleId",
                table: "SpeakerEventSimples",
                newName: "IX_SpeakerEventSimples_EventSimpleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEventSimples",
                table: "SpeakerEventSimples",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimples_EventSimples_EventSimpleId",
                table: "SpeakerEventSimples",
                column: "EventSimpleId",
                principalTable: "EventSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimples_Speakers_SpeakerId",
                table: "SpeakerEventSimples",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimples_EventSimples_EventSimpleId",
                table: "SpeakerEventSimples");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEventSimples_Speakers_SpeakerId",
                table: "SpeakerEventSimples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEventSimples",
                table: "SpeakerEventSimples");

            migrationBuilder.RenameTable(
                name: "SpeakerEventSimples",
                newName: "SpeakerEventSimple");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEventSimples_SpeakerId",
                table: "SpeakerEventSimple",
                newName: "IX_SpeakerEventSimple_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEventSimples_EventSimpleId",
                table: "SpeakerEventSimple",
                newName: "IX_SpeakerEventSimple_EventSimpleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEventSimple",
                table: "SpeakerEventSimple",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimple_EventSimples_EventSimpleId",
                table: "SpeakerEventSimple",
                column: "EventSimpleId",
                principalTable: "EventSimples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEventSimple_Speakers_SpeakerId",
                table: "SpeakerEventSimple",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
