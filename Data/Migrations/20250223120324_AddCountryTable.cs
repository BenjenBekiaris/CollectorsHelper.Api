using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CollectorsHelper.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CollectibleItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Slovakia" },
                    { 2, "Germany" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectibleItems_CountryId",
                table: "CollectibleItems",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectibleItems_Countries_CountryId",
                table: "CollectibleItems",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectibleItems_Countries_CountryId",
                table: "CollectibleItems");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_CollectibleItems_CountryId",
                table: "CollectibleItems");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CollectibleItems");
        }
    }
}
