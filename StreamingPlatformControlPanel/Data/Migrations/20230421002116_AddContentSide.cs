using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingPlatformControlPanel.Data.Migrations
{
    public partial class AddContentSide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmMakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmMakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CertificationId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmMakerFilmRole",
                columns: table => new
                {
                    FilmMakersId = table.Column<int>(type: "int", nullable: false),
                    FilmRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmMakerFilmRole", x => new { x.FilmMakersId, x.FilmRolesId });
                    table.ForeignKey(
                        name: "FK_FilmMakerFilmRole_FilmMakers_FilmMakersId",
                        column: x => x.FilmMakersId,
                        principalTable: "FilmMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmMakerFilmRole_FilmRoles_FilmRolesId",
                        column: x => x.FilmRolesId,
                        principalTable: "FilmRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmMakerRoles",
                columns: table => new
                {
                    FilmMakerId = table.Column<int>(type: "int", nullable: false),
                    FilmRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmMakerRoles", x => new { x.FilmMakerId, x.FilmRoleId });
                    table.ForeignKey(
                        name: "FK_FilmMakerRoles_FilmMakers_FilmMakerId",
                        column: x => x.FilmMakerId,
                        principalTable: "FilmMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmMakerRoles_FilmRoles_FilmRoleId",
                        column: x => x.FilmRoleId,
                        principalTable: "FilmRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryContent",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ContentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryContent", x => new { x.CategoriesId, x.ContentsId });
                    table.ForeignKey(
                        name: "FK_CategoryContent_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryContent_Contents_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentCategories",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCategories", x => new { x.CategoryId, x.ContentId });
                    table.ForeignKey(
                        name: "FK_ContentCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentCategories_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentFilmMaker",
                columns: table => new
                {
                    ContentsId = table.Column<int>(type: "int", nullable: false),
                    FilmMakersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentFilmMaker", x => new { x.ContentsId, x.FilmMakersId });
                    table.ForeignKey(
                        name: "FK_ContentFilmMaker_Contents_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentFilmMaker_FilmMakers_FilmMakersId",
                        column: x => x.FilmMakersId,
                        principalTable: "FilmMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentFilmMakers",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    FilmMakerId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentFilmMakers", x => new { x.FilmMakerId, x.Role, x.ContentId });
                    table.ForeignKey(
                        name: "FK_ContentFilmMakers_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentFilmMakers_FilmMakers_FilmMakerId",
                        column: x => x.FilmMakerId,
                        principalTable: "FilmMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailerPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationTimeInHour = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOfSeason = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationTimeInHour = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episods_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryContent_ContentsId",
                table: "CategoryContent",
                column: "ContentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentCategories_ContentId",
                table: "ContentCategories",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentFilmMaker_FilmMakersId",
                table: "ContentFilmMaker",
                column: "FilmMakersId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentFilmMakers_ContentId",
                table: "ContentFilmMakers",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CertificationId",
                table: "Contents",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Episods_SeasonId",
                table: "Episods",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmMakerFilmRole_FilmRolesId",
                table: "FilmMakerFilmRole",
                column: "FilmRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmMakerRoles_FilmRoleId",
                table: "FilmMakerRoles",
                column: "FilmRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ContentId",
                table: "Movies",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeriesId",
                table: "Seasons",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ContentId",
                table: "Series",
                column: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryContent");

            migrationBuilder.DropTable(
                name: "ContentCategories");

            migrationBuilder.DropTable(
                name: "ContentFilmMaker");

            migrationBuilder.DropTable(
                name: "ContentFilmMakers");

            migrationBuilder.DropTable(
                name: "Episods");

            migrationBuilder.DropTable(
                name: "FilmMakerFilmRole");

            migrationBuilder.DropTable(
                name: "FilmMakerRoles");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "FilmMakers");

            migrationBuilder.DropTable(
                name: "FilmRoles");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Certifications");
        }
    }
}
