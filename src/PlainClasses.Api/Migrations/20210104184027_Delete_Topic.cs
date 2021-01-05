using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlainClasses.Api.Migrations
{
    public partial class Delete_Topic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EduBlockSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_EduBlockSubjects_EduBlockSubjectId",
                        column: x => x.EduBlockSubjectId,
                        principalTable: "EduBlockSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_EduBlockSubjectId",
                table: "Topics",
                column: "EduBlockSubjectId");
        }
    }
}
