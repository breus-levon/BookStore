using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class v08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                schema: "public",
                table: "Books",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                schema: "public",
                table: "Books");
        }
    }
}
