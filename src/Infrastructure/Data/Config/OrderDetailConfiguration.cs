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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.Property(o => o.Quantity).IsRequired();
           // builder.HasOne(o => o.Product).WithMany().HasForeignKey(o => o.ProductId);
           // builder.HasOne(o => o.Order).WithMany().HasForeignKey(o => o.OrderId);
        }
    }
}
