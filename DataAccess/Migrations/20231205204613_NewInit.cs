using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOLIDDEMO.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Orders_OrderModelOrderId",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_OrderModelOrderId",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "OrderModelOrderId",
                table: "CustomerOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "CustomerOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_OrderId",
                table: "CustomerOrders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Orders_OrderId",
                table: "CustomerOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Orders_OrderId",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_OrderId",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CustomerOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderModelOrderId",
                table: "CustomerOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_OrderModelOrderId",
                table: "CustomerOrders",
                column: "OrderModelOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Orders_OrderModelOrderId",
                table: "CustomerOrders",
                column: "OrderModelOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
