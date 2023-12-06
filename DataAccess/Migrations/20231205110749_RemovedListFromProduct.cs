using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOLIDDEMO.Migrations
{
    /// <inheritdoc />
    public partial class RemovedListFromProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductModelProductId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ProductModelProductId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ProductModelProductId",
                table: "OrderProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductModelProductId",
                table: "OrderProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductModelProductId",
                table: "OrderProducts",
                column: "ProductModelProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductModelProductId",
                table: "OrderProducts",
                column: "ProductModelProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
