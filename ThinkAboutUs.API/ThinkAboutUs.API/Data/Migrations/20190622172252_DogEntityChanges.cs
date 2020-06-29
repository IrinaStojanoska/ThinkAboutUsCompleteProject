using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinkAboutUs.API.Data.Migrations
{
    public partial class DogEntityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dogs",
                newName: "Size");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Dogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Dogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Dogs");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Dogs",
                newName: "Name");
        }
    }
}
