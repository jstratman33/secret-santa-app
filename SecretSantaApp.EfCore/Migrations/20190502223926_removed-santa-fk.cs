using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSantaApp.EfCore.Migrations
{
    public partial class removedsantafk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_SantaId",
                table: "Lists");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_SantaId",
                table: "Lists",
                column: "SantaId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_SantaId",
                table: "Lists");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_SantaId",
                table: "Lists",
                column: "SantaId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
