using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Payments2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(7663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(1738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(4139),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(3086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(7487),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(4589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(5675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(9479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(7289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    DatePay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(5912)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(3186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(9156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(1407),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(8382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(4589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(2465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(4423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(1907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722));
        }
    }
}
