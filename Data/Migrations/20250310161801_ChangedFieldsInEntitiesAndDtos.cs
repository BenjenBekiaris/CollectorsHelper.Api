using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorsHelper.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFieldsInEntitiesAndDtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateWhenAdded",
                table: "CollectibleItems",
                newName: "LastEdit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastEdit",
                table: "CollectibleItems",
                newName: "DateWhenAdded");
        }
    }
}
