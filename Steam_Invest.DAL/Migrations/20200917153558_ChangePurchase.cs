using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Steam_Invest.DAL.Migrations
{
    public partial class ChangePurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyCount",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "BuyDate",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSale",
                table: "Purchases",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Purchases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "IsSale",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "BuyCount",
                table: "Purchases",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyDate",
                table: "Purchases",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyPrice",
                table: "Purchases",
                type: "numeric",
                nullable: true);
        }
    }
}
