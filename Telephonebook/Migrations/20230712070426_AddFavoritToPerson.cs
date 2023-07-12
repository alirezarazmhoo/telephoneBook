using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telephonebook.Migrations
{
    public partial class AddFavoritToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorit",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorit",
                table: "Person");
        }
    }
}
