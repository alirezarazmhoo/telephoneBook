using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telephonebook.Migrations
{
    public partial class AddContactGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactGroupId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_ContactGroupId",
                table: "Person",
                column: "ContactGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_ContactGroups_ContactGroupId",
                table: "Person",
                column: "ContactGroupId",
                principalTable: "ContactGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_ContactGroups_ContactGroupId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "ContactGroups");

            migrationBuilder.DropIndex(
                name: "IX_Person_ContactGroupId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ContactGroupId",
                table: "Person");
        }
    }
}
