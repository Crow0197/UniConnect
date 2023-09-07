using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreate2255333322224545 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gruppo_GruppoGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Commento_AspNetUsers_UserId",
                table: "Commento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pg_AspNetUsers_ApplicationUserId",
                table: "Pg");

            migrationBuilder.DropIndex(
                name: "IX_Pg_ApplicationUserId",
                table: "Pg");

            migrationBuilder.DropIndex(
                name: "IX_Commento_UserId",
                table: "Commento");

            migrationBuilder.RenameColumn(
                name: "GruppoGroupId",
                table: "AspNetUsers",
                newName: "CommentoCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GruppoGroupId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CommentoCommentId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Pg",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserGruppo",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGruppo", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGruppo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGruppo_Gruppo_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Gruppo",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGruppo_UserId",
                table: "ApplicationUserGruppo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Commento_CommentoCommentId",
                table: "AspNetUsers",
                column: "CommentoCommentId",
                principalTable: "Commento",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Commento_CommentoCommentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUserGruppo");

            migrationBuilder.RenameColumn(
                name: "CommentoCommentId",
                table: "AspNetUsers",
                newName: "GruppoGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CommentoCommentId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GruppoGroupId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Pg",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commento",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pg_ApplicationUserId",
                table: "Pg",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Commento_UserId",
                table: "Commento",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gruppo_GruppoGroupId",
                table: "AspNetUsers",
                column: "GruppoGroupId",
                principalTable: "Gruppo",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commento_AspNetUsers_UserId",
                table: "Commento",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pg_AspNetUsers_ApplicationUserId",
                table: "Pg",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
