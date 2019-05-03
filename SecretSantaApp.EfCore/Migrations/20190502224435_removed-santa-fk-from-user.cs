using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSantaApp.EfCore.Migrations
{
    public partial class removedsantafkfromuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_SantaId",
                table: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Lists_SantaId",
                table: "Lists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lists_SantaId",
                table: "Lists",
                column: "SantaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_SantaId",
                table: "Lists",
                column: "SantaId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
