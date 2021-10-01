using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(x => x.BookName)
                .IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price)
                .IsRequired().HasColumnType("decimal(18,2)");
           builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(250);
            
        }
    }
}