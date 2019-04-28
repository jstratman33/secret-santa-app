using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSantaApp.EfCore.Migrations
{
    public partial class changedhashcolumntostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hash",
                table: "Invites",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Hash",
                table: "Invites",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
