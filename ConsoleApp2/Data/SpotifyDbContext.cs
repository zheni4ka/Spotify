using ConsoleApp2.Entities;
using ConsoleApp2.Entities.NewFolder;
using ConsoleApp2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace ConsoleApp2.Data
{
    internal class SpotifyDbContext : DbContext
    {

        public SpotifyDbContext() : base()
        {
            base.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpotifyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(conn);
        }

        public void AddTracksIntoPlaylist()
        {
            int Track_choice, Playlist_Choice;

            foreach(var i in Playlists) 
                Console.WriteLine(i.Id + " ----- " + i.Name);
            
            Console.Write("Choose playlist you wanna add tracks into\n>>> ");
            Playlist_Choice = Convert.ToInt32(Console.ReadLine());

            do
            {

                foreach(var item in Tracks) 
                {
                    Console.WriteLine(item.Id + " ----- " + item.Name);
                }
                
                Console.Write("Enter a id of track you wanna add (type 0 to stop) >>> ");
                Track_choice = Convert.ToInt32(Console.ReadLine());

                Playlists.Where(x => x.Id == Playlist_Choice).First().Tracks.Add(Tracks.Where(x => x.Id == Track_choice).First());
                
                Console.Clear();

            }while(Track_choice != 0);
        }

        public void CreatePlaylist()
        {
            string name_;

            Console.WriteLine("Enter a name of your new playlist\n>>> ");
            name_ = Console.ReadLine();
            
            Console.Clear();

            foreach(var i in Categories) Console.WriteLine(i.Id + "-----" + i.Name);
            Console.Write("Choose a category to your playlist >>> ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id > Categories.Max(x => x.Id) || id < Categories.Min(x => x.Id)) return;

            Playlist n = new() { Name = name_, CategoryId = id};

            Playlists.Add(n);
            SaveChanges();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(new[]
            {
                new Country() { Id = 1, Name = "Ukraine" },
                new Country() { Id = 2, Name = "United States" },
                new Country() { Id = 3, Name = "United Kingdom" },
                new Country() { Id = 4, Name = "Canada" },
                new Country() { Id = 5, Name = "Australia" },
                new Country() { Id = 6, Name = "Germany" },
                new Country() { Id = 7, Name = "France" },
                new Country() { Id = 8, Name = "Japan" },
                new Country() { Id = 9, Name = "Brazil" },
                new Country() { Id = 10, Name = "India" }
            });

            modelBuilder.Entity<Track>().HasData(new[]
            {
                new Track() { Id = 1, Name = "STARGAZING", AlbumId = 1, Duration = TimeSpan.FromMinutes(4) },
                new Track() { Id = 2, Name = "CAROUSEL", AlbumId = 1, Duration = TimeSpan.FromMinutes(3) },
                new Track() { Id = 3, Name = "SICKO MODE", AlbumId = 1, Duration = TimeSpan.FromMinutes(5) },
                new Track() { Id = 4, Name = "R.I.P. SCREW", AlbumId = 1, Duration = TimeSpan.FromMinutes(3) },

            });

            modelBuilder.Entity<Album>().HasData(new[]
            {
                new Album() {Id = 1, GenreId = 3, Name = "ASTROWORLD", Year = 2018, Rating = 8, ArtistId = 1}
            });

            modelBuilder.Entity<Artist>().HasData(new[]
            {
                new Artist() { Id = 1, CountryId = 2, Name = "Travis", Surname = "Scott"}
            });

            modelBuilder.Entity<Category>().HasData(new[]
            {       
                new Category() { Id = 1, Name = "Chill" },
                new Category() { Id = 2, Name = "Action" },
                new Category() { Id = 3, Name = "Adventure" },
                new Category() { Id = 4, Name = "Romance" },
                new Category() { Id = 5, Name = "Science Fiction" },
                new Category() { Id = 6, Name = "Fantasy" },
                new Category() { Id = 7, Name = "Mystery" },
                new Category() { Id = 8, Name = "Horror" },
                new Category() { Id = 9, Name = "Comedy" },
                new Category() { Id = 10, Name = "Drama" }
            });

            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() { Id = 1, Name = "Rock" },
                new Genre() { Id = 2, Name = "Pop" },
                new Genre() { Id = 3, Name = "Hip Hop" },
                new Genre() { Id = 4, Name = "Electronic" },
                new Genre() { Id = 5, Name = "R&B" },
                new Genre() { Id = 6, Name = "Country" },
                new Genre() { Id = 7, Name = "Jazz" },
                new Genre() { Id = 8, Name = "Classical" },
                new Genre() { Id = 9, Name = "Metal" },
                new Genre() { Id = 10, Name = "Folk" }
            });
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}