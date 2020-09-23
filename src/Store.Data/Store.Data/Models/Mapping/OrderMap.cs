using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Store.Data.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            HasKey(t => t.OrderId);

            // Properties
            Property(t => t.Number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.ClientId)
                .IsRequired();

            Property(t => t.CreatedOn)
                .IsRequired();

            Property(t => t.Value)
                .IsRequired();


            // Table & Column Mappings
            ToTable("Order");
            Property(t => t.OrderId).HasColumnName("OrderId");
            Property(t => t.Number).HasColumnName("Number");
            Property(t => t.ClientId).HasColumnName("ClientId");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.Value).HasColumnName("Value");

            // Relationships
            HasRequired(t => t.Client)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.ClientId);
        }
    }
}
