using System.Data.Entity.ModelConfiguration;

namespace Store.Data.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            HasKey(t => t.ClientId);

            // Properties
            Property(t => t.CreatedOn)
                .IsRequired();

            Property(t => t.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.Cpf)
                .HasMaxLength(20)
                .IsRequired();

            Property(t => t.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.Password)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.Status)
                .IsRequired();
            
            // Table & Column Mappings
            ToTable("Client");
            Property(t => t.ClientId).HasColumnName("ClientId");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.FirstName).HasColumnName("FirstName");
            Property(t => t.LastName).HasColumnName("LastName");
            Property(t => t.Cpf).HasColumnName("Cpf");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Password).HasColumnName("Password");
            Property(t => t.Status).HasColumnName("Status");
        }
    }
}
