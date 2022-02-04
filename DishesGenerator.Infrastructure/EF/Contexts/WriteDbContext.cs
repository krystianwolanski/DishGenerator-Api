using DishesGenerator.Domain.Entities;
using DishesGenerator.Domain.ValueObjects;
using DishesGenerator.Infrastructure.EF.Config;
using DishesGenerator.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DishesGenerator.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<DishWriteModel> Dishes { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new WriteConfiguration();

            modelBuilder.ApplyConfiguration<DishWriteModel>(configuration);
            modelBuilder.ApplyConfiguration<DishIngredientWriteModel>(configuration);
            modelBuilder.ApplyConfiguration<IngredientInfoWriteModel>(configuration);
        }
    }
}
