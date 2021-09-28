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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(o => o.CustomerName).IsRequired().HasMaxLength(75);
            builder.Property(o => o.Ammount).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.ShipDate).IsRequired();
            builder.HasOne(o => o.OrderStatus).WithMany().HasForeignKey(x => x.OrderStatusId);
            builder.HasOne(o => o.Customer).WithMany().HasForeignKey(x => x.CustomerId);
        }
    }
}
