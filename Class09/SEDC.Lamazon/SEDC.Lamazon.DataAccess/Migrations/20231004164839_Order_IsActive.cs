using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.Lamazon.DataAccess.Migrations
{
    public partial class Order_IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAELXPrdWxefndS1tSvZVPHh2zV5Kkd+pek6BZ8pfy/lHkStApp+/gwMcfNixhBw2xjA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEI39YOrKcp+XW+nZ6/tZADfS1eGqE2uppcTrCsbFNjsvyl62lNNYgYZ0I1BCB/QdhA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPyu4I81HzcJfc6vsJ52LyArsYQjZ7M07gAaVdvhPDMYj7/fJJVpw72dN/bgCOR5dQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM1cljzIK/hn23jrKebXFW3xZpgEBqyGPzJATV5uEwCEy9+PTI8JLSdSkVA2sO2mMg==");
        }
    }
}
