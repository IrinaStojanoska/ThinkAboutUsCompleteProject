using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinkAboutUs.API.Data.Migrations
{
    public partial class KeyChangesInEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reports_DogId",
                table: "Reports");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DogId",
                table: "Reports",
                column: "DogId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reports_DogId",
                table: "Reports");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DogId",
                table: "Reports",
                column: "DogId");
        }
    }
}
