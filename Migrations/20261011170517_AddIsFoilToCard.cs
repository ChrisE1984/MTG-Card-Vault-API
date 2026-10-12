using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTG_Card_Vault_API.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFoilToCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFoil",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFoil",
                table: "Cards");
        }
    }
}
