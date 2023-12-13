using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Order_Management.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "BillingAddresses",
                schema: "Orders",
                columns: table => new
                {
                    BillingAddresssID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BillingAddresss_Shopname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddresss_Shopnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddresss_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddresss_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddresss_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddresss_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddresses", x => x.BillingAddresssID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Orders",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Orders",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                schema: "Orders",
                columns: table => new
                {
                    ShippingAddressID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShippingAddress_HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.ShippingAddressID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    DeliveryCharge = table.Column<double>(type: "float", nullable: false),
                    OrderNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    isCreatedByStaff = table.Column<bool>(type: "bit", nullable: false),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ShippingAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BillingAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_BillingAddresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalSchema: "Orders",
                        principalTable: "BillingAddresses",
                        principalColumn: "BillingAddresssID");
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Orders",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ShippingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalSchema: "Orders",
                        principalTable: "ShippingAddresses",
                        principalColumn: "ShippingAddressID");
                });

            migrationBuilder.CreateTable(
                name: "OrderOrderItem",
                schema: "Orders",
                columns: table => new
                {
                    OrderedItemsOrderItemId = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderItem", x => new { x.OrderedItemsOrderItemId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_OrderItem_OrderedItemsOrderItemId",
                        column: x => x.OrderedItemsOrderItemId,
                        principalSchema: "Orders",
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalSchema: "Orders",
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderItem_OrdersOrderId",
                schema: "Orders",
                table: "OrderOrderItem",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                schema: "Orders",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Orders",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                schema: "Orders",
                table: "Orders",
                column: "ShippingAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOrderItem",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "BillingAddresses",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "ShippingAddresses",
                schema: "Orders");
        }
    }
}
