using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreatessfdfdbnbfvds121321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "765d5290-adb4-42f9-8ff8-56c3deb1d960",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a53a018c-3339-4fc3-9719-6a947222193c", "AQAAAAEAACcQAAAAEHNCOhKbZFJTX3++GYit4ijVWLvigvmmhUilbT0qj5PXNfbtStxNpP+T6/GHxgnkrA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "765d5290-adb4-42f9-8ff8-56c3deb1d960",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8aa92037-d038-413e-b271-0c7c2f62ee4a", "AQAAAAEAACcQAAAAEJR/whb3rVmra/JW5ZT1Cpa9aFnuic2pWiQA6t+2UrpyWvPGuW/hLgcM/6mj6rTBDw==" });
        }
    }
}
