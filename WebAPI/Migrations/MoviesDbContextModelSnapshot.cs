﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    partial class MoviesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 6
                        },
                        new
                        {
                            CharacterId = 5,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 5,
                            MovieId = 5
                        },
                        new
                        {
                            CharacterId = 6,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 6,
                            MovieId = 5
                        },
                        new
                        {
                            CharacterId = 7,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 7,
                            MovieId = 6
                        },
                        new
                        {
                            CharacterId = 8,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 8,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 8,
                            MovieId = 9
                        },
                        new
                        {
                            CharacterId = 9,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 9,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 9,
                            MovieId = 9
                        },
                        new
                        {
                            CharacterId = 10,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 10,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 10,
                            MovieId = 9
                        },
                        new
                        {
                            CharacterId = 11,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 11,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 11,
                            MovieId = 9
                        },
                        new
                        {
                            CharacterId = 12,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 12,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 12,
                            MovieId = 9
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(736)
                        .HasColumnType("nvarchar(736)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Superman",
                            FullName = "Clark Kent",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/superman.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Batman",
                            FullName = "Bruce Wayne",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/batman.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Harley Quinn",
                            FullName = "Harleen Quinzel",
                            Gender = "Female",
                            PictureURL = "https://www.example.com/harley_quinn.jpg"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Dr. Alan Grant",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/alan_grant.jpg"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Ian Malcolm",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/ian_malcolm.jpg"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "John Hammond",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/john_hammond.jpg"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Dr. Ellie Sattler",
                            Gender = "Female",
                            PictureURL = "https://www.example.com/ellie_sattler.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Alias = "Jack Sparrow",
                            FullName = "Captain Jack Sparrow",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/jack_sparrow.jpg"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Elizabeth Swann",
                            Gender = "Female",
                            PictureURL = "https://www.example.com/elizabeth_swann.jpg"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Will Turner",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/will_turner.jpg"
                        },
                        new
                        {
                            Id = 11,
                            Alias = "Barbossa",
                            FullName = "Hector Barbossa",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/barbossa.jpg"
                        },
                        new
                        {
                            Id = 12,
                            Alias = "Gibbs",
                            FullName = "Joshamee Gibbs",
                            Gender = "Male",
                            PictureURL = "https://www.example.com/gibbs.jpg"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Superhero movies based on DC Comics characters.",
                            Name = "DC Extended Universe"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Adventure movies about cloned dinosaurs.",
                            Name = "Jurassic Park"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Adventure movies about pirates.",
                            Name = "Pirates of the Caribbean"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(736)
                        .HasColumnType("nvarchar(736)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TrailerURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Zack Snyder",
                            FranchiseId = 1,
                            Genre = "Action, Adventure, Fantasy",
                            PosterURL = "https://xl.movieposterdb.com/13_05/2013/770828/xl_770828_b1a0c77c.jpg",
                            ReleaseYear = 2013,
                            Title = "Man of Steel",
                            TrailerURL = "https://www.youtube.com/watch?v=T6DJcgm3wNY"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Zack Snyder",
                            FranchiseId = 1,
                            Genre = "Action, Adventure, Sci-Fi",
                            PosterURL = "https://xl.movieposterdb.com/22_06/2016/2975590/xl_2975590_dc17b3fd.jpg",
                            ReleaseYear = 2016,
                            Title = "Batman v Superman: Dawn of Justice",
                            TrailerURL = "https://www.youtube.com/watch?v=0WWzgGyAH6Y"
                        },
                        new
                        {
                            Id = 3,
                            Director = "David Ayer",
                            FranchiseId = 1,
                            Genre = "Action, Adventure, Fantasy",
                            PosterURL = "https://xl.movieposterdb.com/21_06/2016/1386697/xl_1386697_d05c9c2e.jpg",
                            ReleaseYear = 2016,
                            Title = "Suicide Squad",
                            TrailerURL = "https://www.youtube.com/watch?v=CmRih_VtVAs"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Steven Spielberg",
                            FranchiseId = 2,
                            Genre = "Action, Adventure, Sci-Fi",
                            PosterURL = "https://xl.movieposterdb.com/05_08/1993/0107290/xl_45298_0107290_be4e0db3.jpg",
                            ReleaseYear = 1993,
                            Title = "Jurassic Park",
                            TrailerURL = "https://www.youtube.com/watch?v=QWBKEmWWL38"
                        },
                        new
                        {
                            Id = 5,
                            Director = "Steven Spielberg",
                            FranchiseId = 2,
                            Genre = "Action, Adventure, Sci-Fi",
                            PosterURL = "https://xl.movieposterdb.com/15_09/1997/369690/xl_369690_4a7bb4f6.jpg",
                            ReleaseYear = 1997,
                            Title = "The Lost World: Jurassic Park",
                            TrailerURL = "https://www.youtube.com/watch?v=xDgOO9vMXVY"
                        },
                        new
                        {
                            Id = 6,
                            Director = "Joe Johnston",
                            FranchiseId = 2,
                            Genre = "Action, Adventure, Sci-Fi",
                            PosterURL = "https://xl.movieposterdb.com/08_02/2001/163025/xl_163025_fc8dba4b.jpg",
                            ReleaseYear = 2001,
                            Title = "Jurassic Park III",
                            TrailerURL = "https://www.youtube.com/watch?v=lc0UehYemQA"
                        },
                        new
                        {
                            Id = 7,
                            Director = "Gore Verbinski",
                            FranchiseId = 3,
                            Genre = "Action, Adventure, Fantasy",
                            PosterURL = "https://xl.movieposterdb.com/10_01/2003/325980/xl_325980_6a4da6c6.jpg",
                            ReleaseYear = 2003,
                            Title = "Pirates of the Caribbean: The Curse of the Black Pearl",
                            TrailerURL = "https://www.youtube.com/watch?v=naQr0uTrH_s"
                        },
                        new
                        {
                            Id = 8,
                            Director = "Gore Verbinski",
                            FranchiseId = 3,
                            Genre = "Action, Adventure, Fantasy",
                            PosterURL = "https://xl.movieposterdb.com/22_12/2006/857391/xl_pirates-of-the-caribbean-secrets-of-dead-mans-chest-movie-poster_b685ac38.jpg",
                            ReleaseYear = 2006,
                            Title = "Pirates of the Caribbean: Dead Man's Chest",
                            TrailerURL = "https://www.youtube.com/watch?v=ozk0-RHXtFw"
                        },
                        new
                        {
                            Id = 9,
                            Director = "Gore Verbinski",
                            FranchiseId = 3,
                            Genre = "Action, Adventure, Fantasy",
                            PosterURL = "https://xl.movieposterdb.com/14_06/2007/449088/xl_449088_1921c5f3.jpg",
                            ReleaseYear = 2007,
                            Title = "Pirates of the Caribbean: At World's End",
                            TrailerURL = "https://www.youtube.com/watch?v=HKSZtp_OGHY"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("WebAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPI.Models.Movie", b =>
                {
                    b.HasOne("WebAPI.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("WebAPI.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
