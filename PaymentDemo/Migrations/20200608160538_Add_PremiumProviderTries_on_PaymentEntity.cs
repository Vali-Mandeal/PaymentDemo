using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentDemo.Migrations
{
    public partial class Add_PremiumProviderTries_on_PaymentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremiumProviderTries",
                table: "Payments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumProviderTries",
                table: "Payments");
        }
    }
}
