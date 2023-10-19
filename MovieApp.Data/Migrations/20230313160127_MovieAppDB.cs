using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MovieAppDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ReleaseYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    DirectorName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MainCast = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorName", "Genre", "LongDescription", "MainCast", "ReleaseYear", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 1, null, 2, null, null, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Very Real Movie" },
                    { 2, null, 3, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Very Real Movie 2" },
                    { 3, null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Just your typical romance.", "Something, something Love" },
                    { 4, null, 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, ".gitignore: The Movie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
