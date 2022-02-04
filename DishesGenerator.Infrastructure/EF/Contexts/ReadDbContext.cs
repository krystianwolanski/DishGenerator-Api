using DishesGenerator.Domain.ValueObjects;
using DishesGenerator.Infrastructure.EF.Config;
using DishesGenerator.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DishesGenerator.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<DishReadModel> Dishes { get; set; }
        public DbSet<IngredientInfoReadModel> IngredientsInfos { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ReadConfiguration();

            modelBuilder.ApplyConfiguration<DishReadModel>(configuration);
            modelBuilder.ApplyConfiguration<DishIngredientReadModel>(configuration);
            modelBuilder.ApplyConfiguration<IngredientInfoReadModel>(configuration);
        }
    }
}
