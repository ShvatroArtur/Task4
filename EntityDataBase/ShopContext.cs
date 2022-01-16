using System.Data.Entity;

namespace EntityDataBase
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("DBConnection") { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleInfo> SaleInfos { get; set; }
    }
}