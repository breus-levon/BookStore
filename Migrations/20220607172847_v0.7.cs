using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class v07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountInStorage",
                schema: "public",
                table: "Books",
                type: "int4",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountInStorage",
                schema: "public",
                table: "Books");
        }
    }
}
