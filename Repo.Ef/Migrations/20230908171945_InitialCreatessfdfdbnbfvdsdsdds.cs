using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreatessfdfdbnbfvdsdsdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "EventoEventId", "FileStorageFileId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "765d5290-adb4-42f9-8ff8-56c3deb1d960", 0, null, "b20ecda1-c754-42eb-9fe4-022339f5312c", "admin@admin.com", true, null, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN", "AQAAAAEAACcQAAAAEMtMqxTWpCIDJ5Vu8S5Oj/Tr6Lx++BX6GnJheQ/9yo+xu0OVOVkolicuuq4IrTA+JQ==", null, false, null, "", false, "admin@admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "765d5290-adb4-42f9-8ff8-56c3deb1d960");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "EventoEventId", "FileStorageFileId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, null, "2a83def8-19b2-490b-a41d-dd5ed5106964", "admin@admin.com", true, null, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN", "AQAAAAEAACcQAAAAEIMvgn5R2Ra27ADrrYHP+yJc4c8EN2QD1JbVNh2yxKMbpuZee4BhBVUFMSkbZ7JaHQ==", null, false, null, "", false, "admin@admin" });
        }
    }
}
