using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSantaApp.EfCore.Migrations
{
    public partial class addedgroupmemberlinkstocontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMemberLink_Groups_GroupId",
                table: "GroupMemberLink");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMemberLink_Users_MemberId",
                table: "GroupMemberLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMemberLink",
                table: "GroupMemberLink");

            migrationBuilder.RenameTable(
                name: "GroupMemberLink",
                newName: "GroupMemberLinks");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMemberLink_MemberId",
                table: "GroupMemberLinks",
                newName: "IX_GroupMemberLinks_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMemberLinks",
                table: "GroupMemberLinks",
                columns: new[] { "GroupId", "MemberId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMemberLinks_Groups_GroupId",
                table: "GroupMemberLinks",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMemberLinks_Users_MemberId",
                table: "GroupMemberLinks",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMemberLinks_Groups_GroupId",
                table: "GroupMemberLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMemberLinks_Users_MemberId",
                table: "GroupMemberLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMemberLinks",
                table: "GroupMemberLinks");

            migrationBuilder.RenameTable(
                name: "GroupMemberLinks",
                newName: "GroupMemberLink");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMemberLinks_MemberId",
                table: "GroupMemberLink",
                newName: "IX_GroupMemberLink_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMemberLink",
                table: "GroupMemberLink",
                columns: new[] { "GroupId", "MemberId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMemberLink_Groups_GroupId",
                table: "GroupMemberLink",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMemberLink_Users_MemberId",
                table: "GroupMemberLink",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
