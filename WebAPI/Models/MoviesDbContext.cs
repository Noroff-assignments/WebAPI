using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class MoviesDbContext : DbContext
    {
        // Sets the tables for the database
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public MoviesDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Franchises
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise { Id = 1, Name = "DC Extended Universe", Description = "Superhero movies based on DC Comics characters." },
                new Franchise { Id = 2, Name = "Jurassic Park", Description = "Adventure movies about cloned dinosaurs." },
                new Franchise { Id = 3, Name = "Pirates of the Caribbean", Description = "Adventure movies about pirates." }
                );
            #endregion

            #region Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Man of Steel", ReleaseYear = 2013, Genre = "Action, Adventure, Fantasy", Director = "Zack Snyder", PosterURL = "https://xl.movieposterdb.com/13_05/2013/770828/xl_770828_b1a0c77c.jpg", TrailerURL = "https://www.youtube.com/watch?v=T6DJcgm3wNY", FranchiseId = 1 },
                new Movie { Id = 2, Title = "Batman v Superman: Dawn of Justice", ReleaseYear = 2016, Genre = "Action, Adventure, Sci-Fi", Director = "Zack Snyder", PosterURL = "https://xl.movieposterdb.com/22_06/2016/2975590/xl_2975590_dc17b3fd.jpg", TrailerURL = "https://www.youtube.com/watch?v=0WWzgGyAH6Y", FranchiseId = 1 },
                new Movie { Id = 3, Title = "Suicide Squad", ReleaseYear = 2016, Genre = "Action, Adventure, Fantasy", Director = "David Ayer", PosterURL = "https://xl.movieposterdb.com/21_06/2016/1386697/xl_1386697_d05c9c2e.jpg", TrailerURL = "https://www.youtube.com/watch?v=CmRih_VtVAs", FranchiseId = 1 },
                new Movie { Id = 4, Title = "Jurassic Park", ReleaseYear = 1993, Genre = "Action, Adventure, Sci-Fi", Director = "Steven Spielberg", PosterURL = "https://xl.movieposterdb.com/05_08/1993/0107290/xl_45298_0107290_be4e0db3.jpg", TrailerURL = "https://www.youtube.com/watch?v=QWBKEmWWL38", FranchiseId = 2 },
                new Movie { Id = 5, Title = "The Lost World: Jurassic Park", ReleaseYear = 1997, Genre = "Action, Adventure, Sci-Fi", Director = "Steven Spielberg", PosterURL = "https://xl.movieposterdb.com/15_09/1997/369690/xl_369690_4a7bb4f6.jpg", TrailerURL = "https://www.youtube.com/watch?v=xDgOO9vMXVY", FranchiseId = 2 },
                new Movie { Id = 6, Title = "Jurassic Park III", ReleaseYear = 2001, Genre = "Action, Adventure, Sci-Fi", Director = "Joe Johnston", PosterURL = "https://xl.movieposterdb.com/08_02/2001/163025/xl_163025_fc8dba4b.jpg", TrailerURL = "https://www.youtube.com/watch?v=lc0UehYemQA", FranchiseId = 2 },
                new Movie { Id = 7, Title = "Pirates of the Caribbean: The Curse of the Black Pearl", ReleaseYear = 2003, Genre = "Action, Adventure, Fantasy", Director = "Gore Verbinski", PosterURL = "https://xl.movieposterdb.com/10_01/2003/325980/xl_325980_6a4da6c6.jpg", TrailerURL = "https://www.youtube.com/watch?v=naQr0uTrH_s", FranchiseId = 3 },
                new Movie { Id = 8, Title = "Pirates of the Caribbean: Dead Man's Chest", ReleaseYear = 2006, Genre = "Action, Adventure, Fantasy", Director = "Gore Verbinski", PosterURL = "https://xl.movieposterdb.com/22_12/2006/857391/xl_pirates-of-the-caribbean-secrets-of-dead-mans-chest-movie-poster_b685ac38.jpg", TrailerURL = "https://www.youtube.com/watch?v=ozk0-RHXtFw", FranchiseId = 3 },
                new Movie { Id = 9, Title = "Pirates of the Caribbean: At World's End", ReleaseYear = 2007, Genre = "Action, Adventure, Fantasy", Director = "Gore Verbinski", PosterURL = "https://xl.movieposterdb.com/14_06/2007/449088/xl_449088_1921c5f3.jpg", TrailerURL = "https://www.youtube.com/watch?v=HKSZtp_OGHY", FranchiseId = 3 }
                );
            #endregion

            #region Characters
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, FullName = "Clark Kent", Alias = "Superman", Gender = "Male", PictureURL = "https://www.example.com/superman.jpg" },
                new Character { Id = 2, FullName = "Bruce Wayne", Alias = "Batman", Gender = "Male", PictureURL = "https://www.example.com/batman.jpg" },
                new Character { Id = 3, FullName = "Harleen Quinzel", Alias = "Harley Quinn", Gender = "Female", PictureURL = "https://www.example.com/harley_quinn.jpg" },
                new Character { Id = 4, FullName = "Dr. Alan Grant", Alias = null, Gender = "Male", PictureURL = "https://www.example.com/alan_grant.jpg" },
                new Character { Id = 5, FullName = "Ian Malcolm", Alias = null, Gender = "Male", PictureURL = "https://www.example.com/ian_malcolm.jpg" },
                new Character { Id = 6, FullName = "John Hammond", Alias = null, Gender = "Male", PictureURL = "https://www.example.com/john_hammond.jpg" },
                new Character { Id = 7, FullName = "Dr. Ellie Sattler", Alias = null, Gender = "Female", PictureURL = "https://www.example.com/ellie_sattler.jpg" },
                new Character { Id = 8, FullName = "Captain Jack Sparrow", Alias = "Jack Sparrow", Gender = "Male", PictureURL = "https://www.example.com/jack_sparrow.jpg" },
                new Character { Id = 9, FullName = "Elizabeth Swann", Alias = null, Gender = "Female", PictureURL = "https://www.example.com/elizabeth_swann.jpg" },
                new Character { Id = 10, FullName = "Will Turner", Alias = null, Gender = "Male", PictureURL = "https://www.example.com/will_turner.jpg" },
                new Character { Id = 11, FullName = "Hector Barbossa", Alias = "Barbossa", Gender = "Male", PictureURL = "https://www.example.com/barbossa.jpg" },
                new Character { Id = 12, FullName = "Joshamee Gibbs", Alias = "Gibbs", Gender = "Male", PictureURL = "https://www.example.com/gibbs.jpg" }
                );
            #endregion

            #region Character to movie relations
            modelBuilder.Entity<Character>()
                .HasMany(cha => cha.Movies)
                .WithMany(mov => mov.Characters)
                .UsingEntity<Dictionary<string, object>>(
                "CharacterMovie",
                l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                mtm =>
                {
                    mtm.HasKey("CharacterId", "MovieId");
                    mtm.HasData(
                        new { CharacterId = 1, MovieId = 1 },
                        new { CharacterId = 1, MovieId = 2 },
                        new { CharacterId = 2, MovieId = 2 },
                        new { CharacterId = 2, MovieId = 3 },
                        new { CharacterId = 3, MovieId = 3 },
                        new { CharacterId = 4, MovieId = 4 },
                        new { CharacterId = 4, MovieId = 6 },
                        new { CharacterId = 5, MovieId = 4 },
                        new { CharacterId = 5, MovieId = 5 },
                        new { CharacterId = 6, MovieId = 4 },
                        new { CharacterId = 6, MovieId = 5 },
                        new { CharacterId = 7, MovieId = 4 },
                        new { CharacterId = 7, MovieId = 6 },
                        new { CharacterId = 8, MovieId = 7 },
                        new { CharacterId = 8, MovieId = 8 },
                        new { CharacterId = 8, MovieId = 9 },
                        new { CharacterId = 9, MovieId = 7 },
                        new { CharacterId = 9, MovieId = 8 },
                        new { CharacterId = 9, MovieId = 9 },
                        new { CharacterId = 10, MovieId = 7 },
                        new { CharacterId = 10, MovieId = 8 },
                        new { CharacterId = 10, MovieId = 9 },
                        new { CharacterId = 11, MovieId = 7 },
                        new { CharacterId = 11, MovieId = 8 },
                        new { CharacterId = 11, MovieId = 9 },
                        new { CharacterId = 12, MovieId = 7 },
                        new { CharacterId = 12, MovieId = 8 },
                        new { CharacterId = 12, MovieId = 9 }
                        );
                });
            #endregion
        }
    }
}
