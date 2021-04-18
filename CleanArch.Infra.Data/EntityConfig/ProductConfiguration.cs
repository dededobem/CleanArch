using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasData(
                new Product(1, "Caderno", "Caderno espiral 100 folhas", 7.50m),
                new Product(2, "Borracha", "Borracha branca pequena", 2.50m),
                new Product(3, "Estojo", "Estojo de plástico pequeno", 5.25m)
                );
        }
    }
}
