using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGruppo");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UtenteGruppo",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtenteGruppo", x => new { x.UserId, x.GroupId });
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserUtenteGruppo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UtenteGruppiUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UtenteGruppiGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserUtenteGruppo", x => new { x.UserId, x.UtenteGruppiUserId, x.UtenteGruppiGroupId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserUtenteGruppo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserUtenteGruppo_UtenteGruppo_UtenteGruppiUserId_UtenteGruppiGroupId",
                        columns: x => new { x.UtenteGruppiUserId, x.UtenteGruppiGroupId },
                        principalTable: "UtenteGruppo",
                        principalColumns: new[] { "UserId", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GruppoUtenteGruppo",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UtenteGruppiUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UtenteGruppiGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruppoUtenteGruppo", x => new { x.GroupId, x.UtenteGruppiUserId, x.UtenteGruppiGroupId });
                    table.ForeignKey(
                        name: "FK_GruppoUtenteGruppo_Gruppo_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Gruppo",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GruppoUtenteGruppo_UtenteGruppo_UtenteGruppiUserId_UtenteGruppiGroupId",
                        columns: x => new { x.UtenteGruppiUserId, x.UtenteGruppiGroupId },
                        principalTable: "UtenteGruppo",
                        principalColumns: new[] { "UserId", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileStorageFileId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, null, "f0963eb1-f14b-440f-a336-92fd1c76865e", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN", "AQAAAAEAACcQAAAAEL1W+zWXYnO3GSL+Dg6/IzGklRLDcGCvESG2BGV5QkYrMdtM39sClMnxjvYQWU8/7w==", null, false, null, "", false, "admin@admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserUtenteGruppo_UtenteGruppiUserId_UtenteGruppiGroupId",
                table: "ApplicationUserUtenteGruppo",
                columns: new[] { "UtenteGruppiUserId", "UtenteGruppiGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_GruppoUtenteGruppo_UtenteGruppiUserId_UtenteGruppiGroupId",
                table: "GruppoUtenteGruppo",
                columns: new[] { "UtenteGruppiUserId", "UtenteGruppiGroupId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserUtenteGruppo");

            migrationBuilder.DropTable(
                name: "GruppoUtenteGruppo");

            migrationBuilder.DropTable(
                name: "UtenteGruppo");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Evento");

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
        }
    }
}
