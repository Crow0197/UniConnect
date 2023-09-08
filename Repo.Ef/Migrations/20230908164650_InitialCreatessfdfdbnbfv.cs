using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreatessfdfdbnbfv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserEvento");

            migrationBuilder.DropTable(
                name: "UtenteGruppo");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Gruppo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventoEventId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "526de621-527d-4ad0-a4c0-948731003979", "AQAAAAEAACcQAAAAELyewEvgAgXxUm7vG2usGypFYPGojQzJ4jZP4ZiDXmMBYU7taLEtxMqYypRaxRpJYg==" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventoEventId",
                table: "AspNetUsers",
                column: "EventoEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGruppo_UserId",
                table: "ApplicationUserGruppo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Evento_EventoEventId",
                table: "AspNetUsers",
                column: "EventoEventId",
                principalTable: "Evento",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Evento_EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUserGruppo");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EventoEventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gruppo");

            migrationBuilder.DropColumn(
                name: "EventoEventId",
                table: "AspNetUsers");

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

            migrationBuilder.CreateTable(
                name: "UtenteGruppo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtenteGruppo", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UtenteGruppo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtenteGruppo_Gruppo_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Gruppo",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92750d5b-5982-4530-bb18-0ef8c5e74689", "AQAAAAEAACcQAAAAEBdO0rfev+OfMcWsYz2AmEhHdXuyzf71Wqtz2PIPL/KLZUkcCK70VYsevMMb6Z3WQg==" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvento_UserId",
                table: "ApplicationUserEvento",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteGruppo_GroupId",
                table: "UtenteGruppo",
                column: "GroupId");
        }
    }
}
