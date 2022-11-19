using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Baskets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 463, DateTimeKind.Local).AddTicks(6764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 581, DateTimeKind.Local).AddTicks(1694));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 462, DateTimeKind.Local).AddTicks(9633),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(5831));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 463, DateTimeKind.Local).AddTicks(4624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 463, DateTimeKind.Local).AddTicks(2634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 462, DateTimeKind.Local).AddTicks(7333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.CreateTable(
                name: "basckets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 462, DateTimeKind.Local).AddTicks(3052)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basckets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BascketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    BascketId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 462, DateTimeKind.Local).AddTicks(5113)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BascketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BascketItems_basckets_BascketId",
                        column: x => x.BascketId,
                        principalTable: "basckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BascketItems_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BascketItems_BascketId",
                table: "BascketItems",
                column: "BascketId");

            migrationBuilder.CreateIndex(
                name: "IX_BascketItems_CatalogItemId",
                table: "BascketItems",
                column: "CatalogItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BascketItems");

            migrationBuilder.DropTable(
                name: "basckets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 581, DateTimeKind.Local).AddTicks(1694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 463, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(5831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 462, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(9833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 463, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(8023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 463, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 13, 2, 28, 580, DateTimeKind.Local).AddTicks(4028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 19, 8, 52, 17, 462, DateTimeKind.Local).AddTicks(7333));
        }
    }
}
