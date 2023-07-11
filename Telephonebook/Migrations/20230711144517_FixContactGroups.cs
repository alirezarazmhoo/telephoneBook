using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telephonebook.Migrations
{
    public partial class FixContactGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_ContactGroups_ContactGroupId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ContactGroupId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ContactGroupId",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "PersonToContractGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ContactGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToContractGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonToContractGroups_ContactGroups_ContactGroupId",
                        column: x => x.ContactGroupId,
                        principalTable: "ContactGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonToContractGroups_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonToContractGroups_ContactGroupId",
                table: "PersonToContractGroups",
                column: "ContactGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToContractGroups_PersonId",
                table: "PersonToContractGroups",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonToContractGroups");

            migrationBuilder.AddColumn<int>(
                name: "ContactGroupId",
                table: "Person",
                type: "int",
                nullable: true);

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
    }
}
