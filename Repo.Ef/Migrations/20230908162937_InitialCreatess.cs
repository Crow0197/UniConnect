using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreatess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserUtenteGruppo");

            migrationBuilder.DropTable(
                name: "GruppoUtenteGruppo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92750d5b-5982-4530-bb18-0ef8c5e74689", "AQAAAAEAACcQAAAAEBdO0rfev+OfMcWsYz2AmEhHdXuyzf71Wqtz2PIPL/KLZUkcCK70VYsevMMb6Z3WQg==" });

            migrationBuilder.CreateIndex(
                name: "IX_UtenteGruppo_GroupId",
                table: "UtenteGruppo",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteGruppo_AspNetUsers_UserId",
                table: "UtenteGruppo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteGruppo_Gruppo_GroupId",
                table: "UtenteGruppo",
                column: "GroupId",
                principalTable: "Gruppo",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtenteGruppo_AspNetUsers_UserId",
                table: "UtenteGruppo");

            migrationBuilder.DropForeignKey(
                name: "FK_UtenteGruppo_Gruppo_GroupId",
                table: "UtenteGruppo");

            migrationBuilder.DropIndex(
                name: "IX_UtenteGruppo_GroupId",
                table: "UtenteGruppo");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f0963eb1-f14b-440f-a336-92fd1c76865e", "AQAAAAEAACcQAAAAEL1W+zWXYnO3GSL+Dg6/IzGklRLDcGCvESG2BGV5QkYrMdtM39sClMnxjvYQWU8/7w==" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserUtenteGruppo_UtenteGruppiUserId_UtenteGruppiGroupId",
                table: "ApplicationUserUtenteGruppo",
                columns: new[] { "UtenteGruppiUserId", "UtenteGruppiGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_GruppoUtenteGruppo_UtenteGruppiUserId_UtenteGruppiGroupId",
                table: "GruppoUtenteGruppo",
                columns: new[] { "UtenteGruppiUserId", "UtenteGruppiGroupId" });
        }
    }
}
