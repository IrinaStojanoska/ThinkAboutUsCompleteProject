using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinkAboutUs.API.Data.Migrations
{
    public partial class AddSizeEntityInDogEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Dogs");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Dogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_SizeId",
                table: "Dogs",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Sizes_SizeId",
                table: "Dogs",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Sizes_SizeId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_SizeId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Dogs");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Dogs",
                nullable: true);
        }
    }
}
