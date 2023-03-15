using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBProject.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tickets_TicketsId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TicketsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TicketsId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TicketId",
                table: "Customers",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tickets_TicketId",
                table: "Customers",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tickets_TicketId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TicketId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "TicketsId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TicketsId",
                table: "Customers",
                column: "TicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tickets_TicketsId",
                table: "Customers",
                column: "TicketsId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
