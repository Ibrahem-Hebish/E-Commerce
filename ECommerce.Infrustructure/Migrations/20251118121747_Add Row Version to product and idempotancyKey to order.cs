using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersiontoproductandidempotancyKeytoorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Products",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "IdempotencyKey",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedAt",
                table: "Products",
                column: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdempotencyKey",
                table: "Orders");
        }
    }
}
