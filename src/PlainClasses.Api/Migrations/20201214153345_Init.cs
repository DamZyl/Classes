using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlainClasses.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auths",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battalions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true),
                    Commander = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battalions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EduBlockSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduBlockSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryRanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BattalionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true),
                    Commander = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Battalions_BattalionId",
                        column: x => x.BattalionId,
                        principalTable: "Battalions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EduBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EduBlockSubjectId = table.Column<Guid>(nullable: false),
                    EduBlockSubjectName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EduBlocks_EduBlockSubjects_EduBlockSubjectId",
                        column: x => x.EduBlockSubjectId,
                        principalTable: "EduBlockSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EduBlockSubjectId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Platoons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true),
                    Commander = table.Column<string>(nullable: true),
                    PersonCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platoons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platoons_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MilitaryRankId = table.Column<Guid>(nullable: false),
                    PlatoonId = table.Column<Guid>(nullable: false),
                    MilitaryRankAcr = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    WorkPhoneNumber = table.Column<string>(nullable: true),
                    PersonalPhoneNumber = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_MilitaryRanks_MilitaryRankId",
                        column: x => x.MilitaryRankId,
                        principalTable: "MilitaryRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Platoons_PlatoonId",
                        column: x => x.PlatoonId,
                        principalTable: "Platoons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatoonInEduBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlatoonId = table.Column<Guid>(nullable: false),
                    EduBlockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatoonInEduBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatoonInEduBlocks_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatoonInEduBlocks_Platoons_PlatoonId",
                        column: x => x.PlatoonId,
                        principalTable: "Platoons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAuths",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    AuthId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAuths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAuths_Auths_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Auths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAuths_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonFunctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    EduBlockId = table.Column<Guid>(nullable: false),
                    Function = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFunctions_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFunctions_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BattalionId",
                table: "Companies",
                column: "BattalionId");

            migrationBuilder.CreateIndex(
                name: "IX_EduBlocks_EduBlockSubjectId",
                table: "EduBlocks",
                column: "EduBlockSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAuths_AuthId",
                table: "PersonAuths",
                column: "AuthId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAuths_PersonId",
                table: "PersonAuths",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFunctions_EduBlockId",
                table: "PersonFunctions",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFunctions_PersonId",
                table: "PersonFunctions",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons",
                column: "MilitaryRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PlatoonId",
                table: "Persons",
                column: "PlatoonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatoonInEduBlocks_EduBlockId",
                table: "PlatoonInEduBlocks",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatoonInEduBlocks_PlatoonId",
                table: "PlatoonInEduBlocks",
                column: "PlatoonId");

            migrationBuilder.CreateIndex(
                name: "IX_Platoons_CompanyId",
                table: "Platoons",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_EduBlockSubjectId",
                table: "Topics",
                column: "EduBlockSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAuths");

            migrationBuilder.DropTable(
                name: "PersonFunctions");

            migrationBuilder.DropTable(
                name: "PlatoonInEduBlocks");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Auths");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "EduBlocks");

            migrationBuilder.DropTable(
                name: "MilitaryRanks");

            migrationBuilder.DropTable(
                name: "Platoons");

            migrationBuilder.DropTable(
                name: "EduBlockSubjects");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Battalions");
        }
    }
}
