using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class oRDERS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(3077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(3785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(8767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(6614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 322, DateTimeKind.Local).AddTicks(9846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 322, DateTimeKind.Local).AddTicks(7454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressState = table.Column<string>(name: "Address_State", type: "nvarchar(max)", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "nvarchar(max)", nullable: false),
                    AddressZipCode = table.Column<string>(name: "Address_ZipCode", type: "nvarchar(max)", nullable: false),
                    AddressPostalAddress = table.Column<string>(name: "Address_PostalAddress", type: "nvarchar(max)", nullable: false),
                    AddressReciverName = table.Column<string>(name: "Address_ReciverName", type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(9565),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(7194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 324, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(8948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(4767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(2138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 323, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(4536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 322, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 11, 13, 43, 322, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 187, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 3, 10, 55, 32, 188, DateTimeKind.Local).AddTicks(7194));
        }
    }
}
