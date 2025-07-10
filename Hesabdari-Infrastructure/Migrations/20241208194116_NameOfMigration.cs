using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesabdari_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NameOfMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "HeroSlides");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "HeroSlides",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "HeroSlides");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "HeroSlides",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
