using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorsHelper.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectibleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ProductionYear = table.Column<int>(type: "INTEGER", nullable: false),
                    DateWhenAdded = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    NumberOfCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectibleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectibleItems_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Coin" });

            migrationBuilder.CreateIndex(
                name: "IX_CollectibleItems_ItemTypeId",
                table: "CollectibleItems",
                column: "ItemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectibleItems");

            migrationBuilder.DropTable(
                name: "ItemTypes");
        }
    }
}
