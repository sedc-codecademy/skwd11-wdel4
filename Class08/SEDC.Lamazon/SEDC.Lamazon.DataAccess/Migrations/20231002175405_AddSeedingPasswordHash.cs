using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.Lamazon.DataAccess.Migrations
{
    public partial class AddSeedingPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAY/lUMLV++3gkggt/jl28XqZuFpE6Bm5PKDBzz5m7zXyGfL4GTqK+FBukMMIYUxjw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAELC0apyxiGuIfePdYlU7Ff3RCoj/ygs/wNkcXLUjd5QaE6xd9hsDcPMjpg+jgIFyVg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "pas123");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "pas456");
        }
    }
}
