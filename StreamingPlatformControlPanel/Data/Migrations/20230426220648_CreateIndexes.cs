using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingPlatformControlPanel.Data.Migrations
{
    public partial class CreateIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryContent");

            migrationBuilder.DropTable(
                name: "ContentFilmMaker");

            migrationBuilder.DropTable(
                name: "FilmMakerFilmRole");

            migrationBuilder.DropIndex(
                name: "IX_Series_ContentId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ContentId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "NumOfSeason",
                table: "Series");

            migrationBuilder.AlterColumn<string>(
                name: "SeasonNum",
                table: "Seasons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FilmRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FilmMakers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EpNum",
                table: "Episods",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Certifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ContentId",
                table: "Series",
                column: "ContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeasonNum_SeriesId",
                table: "Seasons",
                columns: new[] { "SeasonNum", "SeriesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ContentId",
                table: "Movies",
                column: "ContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmRoles_Name",
                table: "FilmRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmMakers_Name",
                table: "FilmMakers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episods_EpNum_SeasonId",
                table: "Episods",
                columns: new[] { "EpNum", "SeasonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_Name",
                table: "Contents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_Name",
                table: "Certifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Series_ContentId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SeasonNum_SeriesId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ContentId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_FilmRoles_Name",
                table: "FilmRoles");

            migrationBuilder.DropIndex(
                name: "IX_FilmMakers_Name",
                table: "FilmMakers");

            migrationBuilder.DropIndex(
                name: "IX_Episods_EpNum_SeasonId",
                table: "Episods");

            migrationBuilder.DropIndex(
                name: "IX_Contents_Name",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_Name",
                table: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "NumOfSeason",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SeasonNum",
                table: "Seasons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FilmRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FilmMakers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EpNum",
                table: "Episods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Series_ContentId",
                table: "Series",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ContentId",
                table: "Movies",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryContent_ContentsId",
                table: "CategoryContent",
                column: "ContentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentFilmMaker_FilmMakersId",
                table: "ContentFilmMaker",
                column: "FilmMakersId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmMakerFilmRole_FilmRolesId",
                table: "FilmMakerFilmRole",
                column: "FilmRolesId");
        }
    }
}
