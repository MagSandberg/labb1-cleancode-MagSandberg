using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOLIDDEMO.Migrations
{
    /// <inheritdoc />
    public partial class RemovedLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerModelCustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerModelCustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerModelCustomerId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerModelCustomerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerModelCustomerId",
                table: "Orders",
                column: "CustomerModelCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerModelCustomerId",
                table: "Orders",
                column: "CustomerModelCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
