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
            builder.Property(x => x.BuyerId)
                .IsRequired()
                .HasMaxLength(40);

            builder.OwnsOne(x => x.ShipToAddress, a =>
            {
                a.WithOwner();

                a.Property(b => b.ZipCode)
                    .IsRequired()
                    .HasMaxLength(18);

                a.Property(b => b.City)
                    .IsRequired()
                    .HasMaxLength(100);

                a.Property(b => b.State)
                    .HasMaxLength(60);

                a.Property(b => b.Country)
                    .IsRequired()
                    .HasMaxLength(90);

                a.Property(b => b.Street)
                    .IsRequired()
                    .HasMaxLength(180);
            });
        }
    }
}
