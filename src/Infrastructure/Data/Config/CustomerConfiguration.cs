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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(c => c.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(75);
            builder.Property(c => c.City).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Country).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(250);
        }
    }
}
