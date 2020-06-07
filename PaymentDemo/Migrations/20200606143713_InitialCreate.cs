using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(nullable: false),
                    CardHolder = table.Column<string>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    SecurityCode = table.Column<string>(maxLength: 3, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ExpensiveProviderTries = table.Column<int>(nullable: false),
                    CheapProviderTries = table.Column<int>(nullable: false),
                    IdState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentStates_IdState",
                        column: x => x.IdState,
                        principalTable: "PaymentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdState",
                table: "Payments",
                column: "IdState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentStates");
        }
    }
}
