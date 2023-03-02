using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(736)", maxLength: 736, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(736)", maxLength: 736, nullable: false),
                    PosterURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "PictureURL" },
                values: new object[,]
                {
                    { 1, "Superman", "Clark Kent", "Male", "https://www.example.com/superman.jpg" },
                    { 2, "Batman", "Bruce Wayne", "Male", "https://www.example.com/batman.jpg" },
                    { 3, "Harley Quinn", "Harleen Quinzel", "Female", "https://www.example.com/harley_quinn.jpg" },
                    { 4, null, "Dr. Alan Grant", "Male", "https://www.example.com/alan_grant.jpg" },
                    { 5, null, "Ian Malcolm", "Male", "https://www.example.com/ian_malcolm.jpg" },
                    { 6, null, "John Hammond", "Male", "https://www.example.com/john_hammond.jpg" },
                    { 7, null, "Dr. Ellie Sattler", "Female", "https://www.example.com/ellie_sattler.jpg" },
                    { 8, "Jack Sparrow", "Captain Jack Sparrow", "Male", "https://www.example.com/jack_sparrow.jpg" },
                    { 9, null, "Elizabeth Swann", "Female", "https://www.example.com/elizabeth_swann.jpg" },
                    { 10, null, "Will Turner", "Male", "https://www.example.com/will_turner.jpg" },
                    { 11, "Barbossa", "Hector Barbossa", "Male", "https://www.example.com/barbossa.jpg" },
                    { 12, "Gibbs", "Joshamee Gibbs", "Male", "https://www.example.com/gibbs.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Superhero movies based on DC Comics characters.", "DC Extended Universe" },
                    { 2, "Adventure movies about cloned dinosaurs.", "Jurassic Park" },
                    { 3, "Adventure movies about pirates.", "Pirates of the Caribbean" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "PosterURL", "ReleaseYear", "Title", "TrailerURL" },
                values: new object[,]
                {
                    { 1, "Zack Snyder", 1, "Action, Adventure, Fantasy", "https://xl.movieposterdb.com/13_05/2013/770828/xl_770828_b1a0c77c.jpg", 2013, "Man of Steel", "https://www.youtube.com/watch?v=T6DJcgm3wNY" },
                    { 2, "Zack Snyder", 1, "Action, Adventure, Sci-Fi", "https://xl.movieposterdb.com/22_06/2016/2975590/xl_2975590_dc17b3fd.jpg", 2016, "Batman v Superman: Dawn of Justice", "https://www.youtube.com/watch?v=0WWzgGyAH6Y" },
                    { 3, "David Ayer", 1, "Action, Adventure, Fantasy", "https://xl.movieposterdb.com/21_06/2016/1386697/xl_1386697_d05c9c2e.jpg", 2016, "Suicide Squad", "https://www.youtube.com/watch?v=CmRih_VtVAs" },
                    { 4, "Steven Spielberg", 2, "Action, Adventure, Sci-Fi", "https://xl.movieposterdb.com/05_08/1993/0107290/xl_45298_0107290_be4e0db3.jpg", 1993, "Jurassic Park", "https://www.youtube.com/watch?v=QWBKEmWWL38" },
                    { 5, "Steven Spielberg", 2, "Action, Adventure, Sci-Fi", "https://xl.movieposterdb.com/15_09/1997/369690/xl_369690_4a7bb4f6.jpg", 1997, "The Lost World: Jurassic Park", "https://www.youtube.com/watch?v=xDgOO9vMXVY" },
                    { 6, "Joe Johnston", 2, "Action, Adventure, Sci-Fi", "https://xl.movieposterdb.com/08_02/2001/163025/xl_163025_fc8dba4b.jpg", 2001, "Jurassic Park III", "https://www.youtube.com/watch?v=lc0UehYemQA" },
                    { 7, "Gore Verbinski", 3, "Action, Adventure, Fantasy", "https://xl.movieposterdb.com/10_01/2003/325980/xl_325980_6a4da6c6.jpg", 2003, "Pirates of the Caribbean: The Curse of the Black Pearl", "https://www.youtube.com/watch?v=naQr0uTrH_s" },
                    { 8, "Gore Verbinski", 3, "Action, Adventure, Fantasy", "https://xl.movieposterdb.com/22_12/2006/857391/xl_pirates-of-the-caribbean-secrets-of-dead-mans-chest-movie-poster_b685ac38.jpg", 2006, "Pirates of the Caribbean: Dead Man's Chest", "https://www.youtube.com/watch?v=ozk0-RHXtFw" },
                    { 9, "Gore Verbinski", 3, "Action, Adventure, Fantasy", "https://xl.movieposterdb.com/14_06/2007/449088/xl_449088_1921c5f3.jpg", 2007, "Pirates of the Caribbean: At World's End", "https://www.youtube.com/watch?v=HKSZtp_OGHY" }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 4 },
                    { 4, 6 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 4 },
                    { 6, 5 },
                    { 7, 4 },
                    { 7, 6 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 9 },
                    { 9, 7 },
                    { 9, 8 },
                    { 9, 9 },
                    { 10, 7 },
                    { 10, 8 },
                    { 10, 9 },
                    { 11, 7 },
                    { 11, 8 },
                    { 11, 9 },
                    { 12, 7 },
                    { 12, 8 },
                    { 12, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
