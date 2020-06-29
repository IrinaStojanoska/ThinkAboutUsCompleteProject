using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinkAboutUs.API.Data.Migrations
{
    public partial class KeyChangesInEntities7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Dogs_ReportEntityId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "ReportEntityId",
                table: "Reports",
                newName: "DogId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reports",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DogId",
                table: "Reports",
                column: "DogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Dogs_DogId",
                table: "Reports",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Dogs_DogId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_DogId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "DogId",
                table: "Reports",
                newName: "ReportEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "ReportEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Dogs_ReportEntityId",
                table: "Reports",
                column: "ReportEntityId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
