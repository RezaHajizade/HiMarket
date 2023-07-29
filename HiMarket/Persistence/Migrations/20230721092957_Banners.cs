using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Banners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 623, DateTimeKind.Local).AddTicks(4196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 623, DateTimeKind.Local).AddTicks(2567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(8258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 623, DateTimeKind.Local).AddTicks(614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(6238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(4188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(5816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(2201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(3256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(1136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(8898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(2181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(47),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 959, DateTimeKind.Local).AddTicks(8806));

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(4188));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(7576),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 623, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(5596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 623, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(412),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 962, DateTimeKind.Local).AddTicks(3250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 623, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(8034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(5534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(5653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(3256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(1136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 622, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(9296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(8898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(1297),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 28, 14, 959, DateTimeKind.Local).AddTicks(8806),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 21, 12, 59, 56, 621, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 960, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2023, 7, 5, 12, 28, 14, 961, DateTimeKind.Local).AddTicks(5534));
        }
    }
}
