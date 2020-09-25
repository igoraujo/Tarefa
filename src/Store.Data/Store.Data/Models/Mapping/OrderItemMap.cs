using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models.Mapping
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            // Primary Key
            HasKey(t => t.OrderItemId);

            // Properties
            Property(t => t.OrderId).IsRequired();

            Property(t => t.ProductId).IsRequired();

            Property(t => t.Quantity).IsRequired();

            // Table & Column Mappings
            ToTable("OrderItem");
            Property(t => t.OrderItemId).HasColumnName("OrderItemId");
            Property(t => t.OrderId).HasColumnName("OrderId");
            Property(t => t.ProductId).HasColumnName("ProductId");
            Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            HasMany(t => t.Products)
                  .WithRequired(t => t.OrderItem)
                  .HasForeignKey(t => t.ProductId);

            HasMany(t => t.Orders)
                   .WithRequired(t => t.OrderItem)
                   .HasForeignKey(t => t.OrderId);
        }
    }
}
