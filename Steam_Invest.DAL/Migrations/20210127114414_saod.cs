using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Steam_Invest.DAL.Migrations
{
    public partial class saod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "BankDepartaments",
                columns: table => new
                {
                    BankDepartamentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankDepartamentName = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDepartaments", x => x.BankDepartamentId);
                    table.ForeignKey(
                        name: "FK_BankDepartaments_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankEmployees",
                columns: table => new
                {
                    BankEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankEmployeeName = table.Column<string>(nullable: true),
                    BankEmployeePosition = table.Column<string>(nullable: true),
                    BankDepartamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEmployees", x => x.BankEmployeeId);
                    table.ForeignKey(
                        name: "FK_BankEmployees_BankDepartaments_BankDepartamentId",
                        column: x => x.BankDepartamentId,
                        principalTable: "BankDepartaments",
                        principalColumn: "BankDepartamentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDepartaments_BankId",
                table: "BankDepartaments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankEmployees_BankDepartamentId",
                table: "BankEmployees",
                column: "BankDepartamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankEmployees");

            migrationBuilder.DropTable(
                name: "BankDepartaments");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
