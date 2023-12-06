using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOLIDDEMO.Migrations
{
    /// <inheritdoc />
    public partial class Addedproductidstoordertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderModelOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderModelOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderModelOrderId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductIds",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderModelOrderId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderModelOrderId",
                table: "Products",
                column: "OrderModelOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderModelOrderId",
                table: "Products",
                column: "OrderModelOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
