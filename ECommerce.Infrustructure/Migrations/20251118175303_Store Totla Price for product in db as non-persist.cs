using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class StoreTotlaPriceforproductindbasnonpersist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "CASE WHEN [HasDiscount] = 0 THEN [Price] ELSE [Price] - ([Price] * [DiscountPercentage] / 100) END",
                stored: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "CASE WHEN [HasDiscount] = 0 THEN [Price] ELSE [Price] - ([Price] * [DiscountPercentage] / 100) END");
        }
    }
}
