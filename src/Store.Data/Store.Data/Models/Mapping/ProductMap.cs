using System.Data.Entity.ModelConfiguration;

namespace Store.Data.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            HasKey(t => t.ProductId);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            ToTable("Product");
            Property(t => t.ProductId).HasColumnName("ProductId");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}
