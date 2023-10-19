using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.Entities;

namespace WebStore.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity<OrderProduct>(
                op => op.HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId),

                op => op.HasOne(op => op.Order)
                .WithMany()
                .HasForeignKey(op => op.OrderId),

                op => {
                    op.HasKey(op => new {op.ProductId, op.OrderId});
                });
        }
    }
}