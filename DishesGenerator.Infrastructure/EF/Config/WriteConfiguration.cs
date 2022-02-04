using DishesGenerator.Domain.Entities;
using DishesGenerator.Domain.ValueObjects;
using DishesGenerator.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DishesGenerator.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration
        : IEntityTypeConfiguration<DishWriteModel>,
        IEntityTypeConfiguration<DishIngredientWriteModel>,
        IEntityTypeConfiguration<IngredientInfoWriteModel>
    {

        public void Configure(EntityTypeBuilder<DishWriteModel> builder)
        {
            builder.Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("Dishes");
        }

        public void Configure(EntityTypeBuilder<DishIngredientWriteModel> builder)
        {
            builder.ToTable("DishIngredients");                
        }

        public void Configure(EntityTypeBuilder<IngredientInfoWriteModel> builder)
        {
            builder.ToTable("IngredientsInfos");
            builder.Property(i => i.PricePer100Grams)
                .HasConversion(i => i.Value, v => new Money(v));
        }
    }
}
