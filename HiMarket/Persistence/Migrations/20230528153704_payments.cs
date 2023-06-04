using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(3186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 351, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(9156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(1407),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 351, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(8382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(4589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(2465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(4423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(1907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(2985));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 351, DateTimeKind.Local).AddTicks(2732),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(8852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 351, DateTimeKind.Local).AddTicks(1070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 34, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(6377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(9344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(4263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(4589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(2165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 33, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(5447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(2985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 19, 7, 4, 32, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 349, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 5, 25, 17, 8, 30, 350, DateTimeKind.Local).AddTicks(6377));
        }
    }
}
