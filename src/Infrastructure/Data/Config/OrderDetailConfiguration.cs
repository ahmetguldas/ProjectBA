using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.Property(o => o.Quantity).IsRequired();
           // builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
           // builder.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId); //

        }
    }
}
