using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CranberryAPI.Migrations
{
    public partial class AddJournalFieldForNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Journals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Journals");
        }
    }
}
