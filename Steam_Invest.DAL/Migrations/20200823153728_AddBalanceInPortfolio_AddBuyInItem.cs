using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Steam_Invest.DAL.Migrations
{
    public partial class AddBalanceInPortfolio_AddBuyInItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LimitCount",
                table: "Portfolios",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Portfolios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyCount",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyDate",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyPrice",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "BuyCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BuyDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "LimitCount",
                table: "Portfolios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
