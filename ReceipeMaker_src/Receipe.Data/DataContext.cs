using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Receipe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Receipe> Receipes { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Resource> Resources { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Requirement>()
                .HasOne(x => x.Resource)
                .WithMany(x => x.Requirements)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Requirement>()
                .HasOne(x => x.Receipe)
                .WithMany(x => x.Requirements)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args) {
            //throw new System.NotImplementedException();

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();

            var connectionString = configuration.GetConnectionString("DataContext");

            builder.UseNpgsql(connectionString);

            return new DataContext(builder.Options);
        }
    }
}