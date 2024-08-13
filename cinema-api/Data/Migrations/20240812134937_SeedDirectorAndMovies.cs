using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema_api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDirectorAndMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fernando Meirelles" },
                    { 2, "José Padilha" },
                    { 3, "Walter Salles" },
                    { 4, "Cao Hamburger" },
                    { 5, "Héctor Babenco" },
                    { 6, "Christopher Nolan" },
                    { 7, "Steven Spielberg" },
                    { 8, "Martin Scorsese" },
                    { 9, "Quentin Tarantino" },
                    { 10, "David Fincher" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "IsInternational", "Title" },
                values: new object[,]
                {
                    { 1, 1, false, "City of God" },
                    { 2, 2, false, "Elite Squad" },
                    { 3, 3, false, "Central Station" },
                    { 4, 4, false, "The Year My Parents Went on Vacation" },
                    { 5, 5, false, "Carandiru" },
                    { 6, 6, true, "Inception" },
                    { 7, 7, true, "E.T. the Extra-Terrestrial" },
                    { 8, 8, true, "Goodfellas" },
                    { 9, 9, true, "Pulp Fiction" },
                    { 10, 10, true, "Fight Club" },
                    { 11, 6, true, "The Grand Budapest Hotel" },
                    { 12, 7, true, "2001: A Space Odyssey" },
                    { 13, 8, true, "Psycho" },
                    { 14, 9, true, "The Godfather" },
                    { 15, 10, true, "The Good, the Bad and the Ugly" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
