using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class Initidsdsddsfddsfdfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Commento_CommentoCommentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Evento_EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CommentoCommentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CommentoCommentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commento",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserEvento",
                columns: table => new
                {
                    EventoEventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEvento", x => new { x.EventoEventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvento_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvento_Evento_EventoEventId",
                        column: x => x.EventoEventId,
                        principalTable: "Evento",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commento_UserId",
                table: "Commento",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvento_UserId",
                table: "ApplicationUserEvento",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commento_AspNetUsers_UserId",
                table: "Commento",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commento_AspNetUsers_UserId",
                table: "Commento");

            migrationBuilder.DropTable(
                name: "ApplicationUserEvento");

            migrationBuilder.DropIndex(
                name: "IX_Commento_UserId",
                table: "Commento");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentoCommentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventoEventId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CommentoCommentId",
                table: "AspNetUsers",
                column: "CommentoCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventoEventId",
                table: "AspNetUsers",
                column: "EventoEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Commento_CommentoCommentId",
                table: "AspNetUsers",
                column: "CommentoCommentId",
                principalTable: "Commento",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Evento_EventoEventId",
                table: "AspNetUsers",
                column: "EventoEventId",
                principalTable: "Evento",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
