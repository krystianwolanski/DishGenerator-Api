using DishesGenerator.Domain.ValueObjects;
using DishesGenerator.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DishesGenerator.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration 
        : IEntityTypeConfiguration<DishReadModel>,
        IEntityTypeConfiguration<DishIngredientReadModel>,
        IEntityTypeConfiguration<IngredientInfoReadModel>
    {
        public void Configure(EntityTypeBuilder<DishReadModel> builder)
        {
            builder.Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();
        }

        public void Configure(EntityTypeBuilder<DishIngredientReadModel> builder)
        {
            builder.ToTable("DishIngredients");

            builder.Property(di => di.GramsWeight)
                .IsRequired();
        }

        public void Configure(EntityTypeBuilder<IngredientInfoReadModel> builder)
        {
            builder.Property(ii => ii.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(ii => ii.Name)
                .IsUnique();

            builder.Property(ii => ii.KcalsPer100Grams)
                 .IsRequired();

            builder.Property(ii => ii.PricePer100Grams)
                .HasConversion(p => p.ToString(), v => new Money(v))
                .IsRequired();

            builder.ToTable("IngredientsInfos");

        }
    }
}
