using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class payment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 201, DateTimeKind.Local).AddTicks(2969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 201, DateTimeKind.Local).AddTicks(1089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(6652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(9200),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(4205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(7362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(2049),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(3706),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(1473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(4205));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(7663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 201, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(5912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 201, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(1738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 104, DateTimeKind.Local).AddTicks(4139),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(9447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(3086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(7487),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(5675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 200, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 103, DateTimeKind.Local).AddTicks(1139),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(9479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 9, 56, 37, 102, DateTimeKind.Local).AddTicks(7289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 11, 20, 18, 199, DateTimeKind.Local).AddTicks(1473));

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
        }
    }
}
