using BlazorCrudDotNet7.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Note;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                    new Note
                    {
                        Id = 1,
                        Title = "PorcaPipetta",
                        Description = "Immos a las pipas",
                        Tag = "pipette",
                        Update = new DateTime(2023, 05, 15, 18, 59, 34)
                    },
                    new Note
                    {
                        Id = 2,
                        Title = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Tag = "Lorem",
                        Update = new DateTime(2023, 05, 16, 17, 04, 00)
                    },
                    new Note
                    {
                        Id = 3,
                        Title = "boh",
                        Description = "boh",
                        Tag = "boh",
                        Update = new DateTime(2023, 05, 17, 12, 30 ,00) 
                    },
                    new Note
                    {
                        Id = 4,
                        Title = "boh1",
                        Description = "boh1",
                        Tag = "boh",
                        Update = new DateTime(2023, 05, 17, 12, 31, 00)
                    }
                );
        }

        public DbSet<Note> Notes => Set<Note>();
    }
}
