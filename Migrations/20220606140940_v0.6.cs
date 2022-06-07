using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class v06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Title",
                schema: "public",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "bookIds",
                schema: "public",
                table: "Authors",
                newName: "BookIds");

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                schema: "public",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfPublication",
                schema: "public",
                table: "Books",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                schema: "public",
                table: "Books",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Title",
                schema: "public",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Publisher",
                schema: "public",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "YearOfPublication",
                schema: "public",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookIds",
                schema: "public",
                table: "Authors",
                newName: "bookIds");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                schema: "public",
                table: "Books",
                column: "Title",
                unique: true);
        }
    }
}
