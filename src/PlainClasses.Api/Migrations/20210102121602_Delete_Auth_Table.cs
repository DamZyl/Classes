using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlainClasses.Api.Migrations
{
    public partial class Delete_Auth_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonAuths_Auths_AuthId",
                table: "PersonAuths");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Platoons_PlatoonId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Auths");

            migrationBuilder.DropIndex(
                name: "IX_PersonAuths_AuthId",
                table: "PersonAuths");

            migrationBuilder.DropColumn(
                name: "PersonCount",
                table: "Platoons");

            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "PersonAuths");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlatoonId",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthName",
                table: "PersonAuths",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndEduBlock",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartEduBlock",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Platoons_PlatoonId",
                table: "Persons",
                column: "PlatoonId",
                principalTable: "Platoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Platoons_PlatoonId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AuthName",
                table: "PersonAuths");

            migrationBuilder.DropColumn(
                name: "EndEduBlock",
                table: "EduBlocks");

            migrationBuilder.DropColumn(
                name: "StartEduBlock",
                table: "EduBlocks");

            migrationBuilder.AddColumn<int>(
                name: "PersonCount",
                table: "Platoons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlatoonId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthId",
                table: "PersonAuths",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Auths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auths", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAuths_AuthId",
                table: "PersonAuths",
                column: "AuthId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAuths_Auths_AuthId",
                table: "PersonAuths",
                column: "AuthId",
                principalTable: "Auths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Platoons_PlatoonId",
                table: "Persons",
                column: "PlatoonId",
                principalTable: "Platoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
