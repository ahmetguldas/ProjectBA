using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.Property(r => r.CustomerName).IsRequired().HasMaxLength(50);
            builder.Property(r => r.CustomerEmail).IsRequired().HasMaxLength(50);
            builder.Property(r => r.Rating).HasMaxLength(50);
            builder.Property(r => r.Comment).IsRequired().HasMaxLength(100);
          //  builder.HasOne(r => r.Product).WithMany().HasForeignKey(r => r.ProductId);
        }
    }
}
