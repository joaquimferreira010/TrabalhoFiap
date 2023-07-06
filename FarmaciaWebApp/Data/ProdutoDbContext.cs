using FarmaciaWebApp.Data.Map;
using FarmaciaWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FarmaciaWebApp.Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) :base(options)
        {

        }


                

        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }

    }

    public class ProdutoDbContextFactory : IDesignTimeDbContextFactory<ProdutoDbContext>
    {
        public ProdutoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProdutoDbContext>();
            //optionsBuilder.Configuration.GetConnectionString("DataBaseProdutos");
            optionsBuilder.UseSqlServer("Server=tcp:db-alurafiap.database.windows.net,1433;Initial Catalog=db_alura;Persist Security Info=False;User ID=azureuser;Password=Filho2023@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ProdutoDbContext(optionsBuilder.Options);
        }
    }
}
