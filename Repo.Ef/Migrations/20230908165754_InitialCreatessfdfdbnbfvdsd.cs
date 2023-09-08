using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Ef.Migrations
{
    public partial class InitialCreatessfdfdbnbfvdsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a83def8-19b2-490b-a41d-dd5ed5106964", "AQAAAAEAACcQAAAAEIMvgn5R2Ra27ADrrYHP+yJc4c8EN2QD1JbVNh2yxKMbpuZee4BhBVUFMSkbZ7JaHQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "526de621-527d-4ad0-a4c0-948731003979", "AQAAAAEAACcQAAAAELyewEvgAgXxUm7vG2usGypFYPGojQzJ4jZP4ZiDXmMBYU7taLEtxMqYypRaxRpJYg==" });
        }
    }
}
