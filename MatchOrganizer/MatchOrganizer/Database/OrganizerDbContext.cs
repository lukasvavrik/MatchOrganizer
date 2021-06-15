using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchOrganizer.Database
{
    public class OrganizerDbContext : DbContext
    {

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ClubUrl> ClubUrl { get; set; }

        private string connectionString = @"server=(localdb)\MSSQLLocalDB;Initial Catalog=OrganizerDb; Integrated Security=true";

        public OrganizerDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public void DeleteDatabase()
        {
            Database.EnsureDeleted();
        }
    }
}
