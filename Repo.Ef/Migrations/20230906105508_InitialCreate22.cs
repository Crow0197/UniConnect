using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreate22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bosses");

            migrationBuilder.DropTable(
                name: "DropUsers");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "StatisticBases");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Typology");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Pg",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "PgID",
                table: "Pg",
                newName: "PgId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pg",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Pg",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "PgId",
                table: "Pg",
                newName: "PgID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pg",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Bosses",
                columns: table => new
                {
                    BossID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ctk = table.Column<int>(type: "int", nullable: false),
                    CtkPost = table.Column<int>(type: "int", nullable: false),
                    Pa = table.Column<int>(type: "int", nullable: false),
                    PaPost = table.Column<int>(type: "int", nullable: false),
                    Pd = table.Column<int>(type: "int", nullable: false),
                    PdPost = table.Column<int>(type: "int", nullable: false),
                    PvPost = table.Column<int>(type: "int", nullable: false),
                    Pvd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bosses", x => x.BossID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemsID);
                });

            migrationBuilder.CreateTable(
                name: "StatisticBases",
                columns: table => new
                {
                    StatisticsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ctk = table.Column<int>(type: "int", nullable: false),
                    Pa = table.Column<int>(type: "int", nullable: false),
                    Pd = table.Column<int>(type: "int", nullable: false),
                    Pvd = table.Column<int>(type: "int", nullable: false),
                    Typology = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticBases", x => x.StatisticsID);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ctk = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Pa = table.Column<int>(type: "int", nullable: false),
                    Pd = table.Column<int>(type: "int", nullable: false),
                    PgID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pvd = table.Column<int>(type: "int", nullable: false),
                    Typology = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsID);
                    table.ForeignKey(
                        name: "FK_Statistics_Pg_PgID",
                        column: x => x.PgID,
                        principalTable: "Pg",
                        principalColumn: "PgID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Typology",
                columns: table => new
                {
                    TypologyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typology", x => x.TypologyID);
                });

            migrationBuilder.CreateTable(
                name: "DropUsers",
                columns: table => new
                {
                    DropUsersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    PgID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropUsers", x => x.DropUsersID);
                    table.ForeignKey(
                        name: "FK_DropUsers_Items_ItemtId",
                        column: x => x.ItemtId,
                        principalTable: "Items",
                        principalColumn: "ItemsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DropUsers_Pg_PgID",
                        column: x => x.PgID,
                        principalTable: "Pg",
                        principalColumn: "PgID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MovesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PgID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypologyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MovesID);
                    table.ForeignKey(
                        name: "FK_Moves_Pg_PgID",
                        column: x => x.PgID,
                        principalTable: "Pg",
                        principalColumn: "PgID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moves_Typology_TypologyID",
                        column: x => x.TypologyID,
                        principalTable: "Typology",
                        principalColumn: "TypologyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DropUsers_ItemtId",
                table: "DropUsers",
                column: "ItemtId");

            migrationBuilder.CreateIndex(
                name: "IX_DropUsers_PgID",
                table: "DropUsers",
                column: "PgID");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PgID",
                table: "Moves",
                column: "PgID");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_TypologyID",
                table: "Moves",
                column: "TypologyID");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_PgID",
                table: "Statistics",
                column: "PgID");
        }
    }
}
