using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Steam_Invest.DAL.Migrations
{
    public partial class AddPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BuyDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "AllBuyCount",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AvgBuyPrice",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstBuyDate",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuyPrice = table.Column<decimal>(nullable: true),
                    BuyDate = table.Column<DateTime>(nullable: true),
                    BuyCount = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ItemId",
                table: "Purchases",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropColumn(
                name: "AllBuyCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AvgBuyPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FirstBuyDate",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "BuyCount",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyDate",
                table: "Items",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyPrice",
                table: "Items",
                type: "numeric",
                nullable: true);
        }
    }
}
