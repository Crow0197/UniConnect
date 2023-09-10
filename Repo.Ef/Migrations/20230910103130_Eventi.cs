using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class Eventi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Evento_EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pg");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "765d5290-adb4-42f9-8ff8-56c3deb1d960");

            migrationBuilder.DropColumn(
                name: "EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Universita",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserEvento",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEvento", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvento_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvento_Evento_EventId",
                        column: x => x.EventId,
                        principalTable: "Evento",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "765d5290-adb4-42f9-8ff8-56c3deb1d961", "1175687a-2a2a-4249-85cf-8c63f3ebbfd0", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvento_UserId",
                table: "ApplicationUserEvento",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserEvento");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "765d5290-adb4-42f9-8ff8-56c3deb1d961");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "Universita",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EventoEventId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pg",
                columns: table => new
                {
                    PgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pg", x => x.PgId);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "EventoEventId", "FileStorageFileId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "765d5290-adb4-42f9-8ff8-56c3deb1d960", 0, null, "a53a018c-3339-4fc3-9719-6a947222193c", "admin@admin.com", true, null, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN", "AQAAAAEAACcQAAAAEHNCOhKbZFJTX3++GYit4ijVWLvigvmmhUilbT0qj5PXNfbtStxNpP+T6/GHxgnkrA==", null, false, null, "", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventoEventId",
                table: "AspNetUsers",
                column: "EventoEventId");

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
