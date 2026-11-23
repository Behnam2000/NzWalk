using Microsoft.EntityFrameworkCore;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Data
{
    public class NZWalksDbContext : DbContext
    {

        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        // These DbSet properties will represent the tables in the database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties table
            // Easy, Medium, Hard
            var deficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("34B56837-4104-43E4-BCB5-AB2AB5E6B424"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("D155AA16-86C0-4E19-B81D-C6CA6EFDDE5C"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("6EBA8810-FAD6-48CB-831F-4B15EB8CDB01"),
                    Name = "Hard"
                }
            };

            // Seed data for Difficulties table (or Database) can be added here in a similar way if needed
            modelBuilder.Entity<Difficulty>().HasData(deficulties);

            // Seed data for Regions table
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("DD669A58-5C7E-4A1A-8F98-6DAA9BA31EEA"),
                    Name = "Northland",
                    Code = "NL",
                    RegionImageUrl = "https://images.pexels.com/photos/32947398/pexels-photo-32947398.jpeg"
                    },
                new Region()
                {
                    Id = Guid.Parse("B6103648-E840-4C25-8726-03B3E1067EEA"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/16575451/pexels-photo-16575451.jpeg"
                    },
                new Region()
                {
                    Id = Guid.Parse("C1FC4257-1A53-4BC6-AA2B-3D3D3A7D463B"),
                    Name = "Waikato",
                    Code = "WKO",
                    RegionImageUrl = "https://images.pexels.com/photos/27105121/pexels-photo-27105121.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("84A16444-BBF4-4C22-A52F-5C64DB3E6281"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("3965A7A3-1CBA-4458-B987-87CE6D751394"),
                    Name = "Gisborne",
                    Code = "GIS",
                    RegionImageUrl = "https://images.pexels.com/photos/21047861/pexels-photo-21047861.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("5F2DEB33-3E15-4E1C-9056-D11323C706BC"),
                    Name = "Hawke's Bay",
                    Code = "HB",
                    RegionImageUrl = null
                }

            };

            // Seed data for Regions table
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
