using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment5Library.Migrations
{
    /// <inheritdoc />
    public partial class Fixpepperonitypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductName",
                value: "Pepperoni Pizza");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductName",
                value: "Peperoni Pizza");
        }
    }
}
