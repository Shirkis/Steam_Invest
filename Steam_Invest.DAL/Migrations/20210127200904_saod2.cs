using Microsoft.EntityFrameworkCore.Migrations;

namespace Steam_Invest.DAL.Migrations
{
    public partial class saod2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDepartaments_Banks_BankId",
                table: "BankDepartaments");

            migrationBuilder.DropForeignKey(
                name: "FK_BankEmployees_BankDepartaments_BankDepartamentId",
                table: "BankEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "BankDepartamentId",
                table: "BankEmployees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "BankDepartaments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankDepartaments_Banks_BankId",
                table: "BankDepartaments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankEmployees_BankDepartaments_BankDepartamentId",
                table: "BankEmployees",
                column: "BankDepartamentId",
                principalTable: "BankDepartaments",
                principalColumn: "BankDepartamentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDepartaments_Banks_BankId",
                table: "BankDepartaments");

            migrationBuilder.DropForeignKey(
                name: "FK_BankEmployees_BankDepartaments_BankDepartamentId",
                table: "BankEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "BankDepartamentId",
                table: "BankEmployees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "BankDepartaments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BankDepartaments_Banks_BankId",
                table: "BankDepartaments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankEmployees_BankDepartaments_BankDepartamentId",
                table: "BankEmployees",
                column: "BankDepartamentId",
                principalTable: "BankDepartaments",
                principalColumn: "BankDepartamentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
