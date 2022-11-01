using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CatalogType_CatalogBrand_update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemove",
                table: "CatalogType",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsRemove",
                table: "CatalogItems",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsRemove",
                table: "CatalogBrand",
                newName: "IsRemoved");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 13, 6, 10, 448, DateTimeKind.Local).AddTicks(434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 41, 13, 930, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 13, 6, 10, 447, DateTimeKind.Local).AddTicks(9418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 41, 13, 930, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 13, 6, 10, 447, DateTimeKind.Local).AddTicks(8370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 41, 13, 930, DateTimeKind.Local).AddTicks(5438));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "CatalogType",
                newName: "IsRemove");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "CatalogItems",
                newName: "IsRemove");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "CatalogBrand",
                newName: "IsRemove");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 41, 13, 930, DateTimeKind.Local).AddTicks(7345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 31, 13, 6, 10, 448, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 41, 13, 930, DateTimeKind.Local).AddTicks(6400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 31, 13, 6, 10, 447, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 41, 13, 930, DateTimeKind.Local).AddTicks(5438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 31, 13, 6, 10, 447, DateTimeKind.Local).AddTicks(8370));
        }
    }
}
