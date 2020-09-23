using Store.Data.Models.Mapping;
using Store.Data.Programmability.Functions;
using Store.Data.Programmability.Stored_Procedures;
using System;
using System.Configuration;
using System.Data.Entity;

namespace Store.Data.Models
{
    public class StoreContextLog : DbContext
    {
        public static string GetConnectionString(string connectionString)
        {
            var azureFunctionsConnection = Environment.GetEnvironmentVariable(connectionString);
            var defaultConnection = ConfigurationManager.ConnectionStrings[connectionString]?.ConnectionString;

            return defaultConnection ?? azureFunctionsConnection ?? connectionString;
        }

        public StoreContextLog(string contextName) : base(GetConnectionString(contextName))
        {
            StoredProcedures = new StoredProcedures(this);
            ScalarValuedFunctions = new ScalarValuedFunctions(this);
            TableValuedFunctions = new TableValuedFunctions(this);
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }


        public StoredProcedures StoredProcedures { get; set; }
        public ScalarValuedFunctions ScalarValuedFunctions { get; set; }
        public TableValuedFunctions TableValuedFunctions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
