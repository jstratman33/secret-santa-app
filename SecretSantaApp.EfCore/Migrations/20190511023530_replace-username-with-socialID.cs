using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSantaApp.EfCore.Migrations
{
    public partial class replaceusernamewithsocialID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "SocialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialId",
                table: "Users",
                newName: "Username");
        }
    }
}
