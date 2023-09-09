using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreatessfdfdbnbfvdsdsddsdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commento_FileStorage_FileId",
                table: "Commento");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_FileStorage_FileId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_FileId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Commento_FileId",
                table: "Commento");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Commento");

            migrationBuilder.AddColumn<int>(
                name: "CommentoCommentId",
                table: "FileStorage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "FileStorage",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "765d5290-adb4-42f9-8ff8-56c3deb1d960",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "8aa92037-d038-413e-b271-0c7c2f62ee4a", "AQAAAAEAACcQAAAAEJR/whb3rVmra/JW5ZT1Cpa9aFnuic2pWiQA6t+2UrpyWvPGuW/hLgcM/6mj6rTBDw==", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_FileStorage_CommentoCommentId",
                table: "FileStorage",
                column: "CommentoCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_FileStorage_PostId",
                table: "FileStorage",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileStorage_Commento_CommentoCommentId",
                table: "FileStorage",
                column: "CommentoCommentId",
                principalTable: "Commento",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileStorage_Post_PostId",
                table: "FileStorage",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileStorage_Commento_CommentoCommentId",
                table: "FileStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_FileStorage_Post_PostId",
                table: "FileStorage");

            migrationBuilder.DropIndex(
                name: "IX_FileStorage_CommentoCommentId",
                table: "FileStorage");

            migrationBuilder.DropIndex(
                name: "IX_FileStorage_PostId",
                table: "FileStorage");

            migrationBuilder.DropColumn(
                name: "CommentoCommentId",
                table: "FileStorage");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "FileStorage");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Commento",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "765d5290-adb4-42f9-8ff8-56c3deb1d960",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "b20ecda1-c754-42eb-9fe4-022339f5312c", "AQAAAAEAACcQAAAAEMtMqxTWpCIDJ5Vu8S5Oj/Tr6Lx++BX6GnJheQ/9yo+xu0OVOVkolicuuq4IrTA+JQ==", "admin@admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Post_FileId",
                table: "Post",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Commento_FileId",
                table: "Commento",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commento_FileStorage_FileId",
                table: "Commento",
                column: "FileId",
                principalTable: "FileStorage",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_FileStorage_FileId",
                table: "Post",
                column: "FileId",
                principalTable: "FileStorage",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
