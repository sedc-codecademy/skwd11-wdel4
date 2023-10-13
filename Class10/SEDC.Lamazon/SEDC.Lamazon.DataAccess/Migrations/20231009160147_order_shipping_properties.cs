using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.Lamazon.DataAccess.Migrations
{
    public partial class order_shipping_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBVKRZWgmFjFTGzs8GN2RJ9U/dnduM/eAbW+a4JbRxa5rJ7KEmPTV102gMbMaw0UNA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEH2mnhxUrdlS1gy1fjsus26CWbHhoN1o9SiCIKppSn5AjCjwe/NATsBz48LMF6NTMQ==");
        }
    }
}
