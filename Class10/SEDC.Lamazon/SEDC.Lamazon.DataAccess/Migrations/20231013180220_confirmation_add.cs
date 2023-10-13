using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.Lamazon.DataAccess.Migrations
{
    public partial class confirmation_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConformationCode",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEA5eGmCBTZHiobGW9NVo+q399w2gJcHftbRO80G/0whL6u865RA0KMh3pR52tzxHUA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBGzoXZdnyHJobp22Gdjmo9BCn3truY/46mr/7f4V0q+qeog8oWwPYnVau4s5FWvcA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConformationCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAELajFm20bokfUbr7ksEAke4Q6n9TCJfDpPqcOMesQu85WftOXx/9zAJJbAhKp2HG2g==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOO3c3ft1gdMBvZnBkkSoicAdjjCiFlRsivxfCaRWxI72ZEBoWw9ITcSv/xISxcc4Q==");
        }
    }
}
