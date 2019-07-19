using FullStackSample.DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackSample.DomainLayer.ServicesImpl
{
	public class FullStackDbContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

		public FullStackDbContext() : base() { }

		public FullStackDbContext(DbContextOptions<FullStackDbContext> options)
			: base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
					@"Server=localhost;Database=FluxorFullStackSampleDB;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder
				.Entity<Client>()
				.HasIndex(x => x.Name)
				.IsUnique()
				.HasName("uidx_Client_Name");
			modelBuilder
				.Entity<Product>()
				.HasIndex(x => x.Name)
				.IsUnique()
				.HasName("uidx_Product_Name");
			modelBuilder
				.Entity<PurchaseOrder>()
				.HasMany<PurchaseOrderLine>(x => x.Lines)
				.WithOne(x => x.Order);
			modelBuilder
				.Entity<ProductType>()
				.HasIndex(x => x.Name)
				.IsUnique()
				.HasName("uidx_ProductType_Name");
		}
	}
}
