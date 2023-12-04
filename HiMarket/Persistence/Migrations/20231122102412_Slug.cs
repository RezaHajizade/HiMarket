using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Slug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 82, DateTimeKind.Local).AddTicks(3828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 470, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 82, DateTimeKind.Local).AddTicks(1677),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 470, DateTimeKind.Local).AddTicks(3586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(6065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(9144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 470, DateTimeKind.Local).AddTicks(1655));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(3480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(8365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(6107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(8409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(4101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(6891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(4856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(1797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 467, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(873));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 470, DateTimeKind.Local).AddTicks(5198),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 82, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 470, DateTimeKind.Local).AddTicks(3586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 82, DateTimeKind.Local).AddTicks(1677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(9266),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 470, DateTimeKind.Local).AddTicks(1655),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(7313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(5260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 81, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(3808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(2465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(8409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(6891),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 80, DateTimeKind.Local).AddTicks(4101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 11, 3, 15, 467, DateTimeKind.Local).AddTicks(7726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 54, 12, 79, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 468, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 11, 22, 11, 3, 15, 469, DateTimeKind.Local).AddTicks(5260));
        }
    }
}
