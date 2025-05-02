using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
  public class AppDBContext : DbContext
  {
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Produto> Produto { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<ItemPedido> ItemPedido { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ItemPedido>().HasOne(p => p.Produto).WithMany().HasForeignKey(p => p.ProdudoId);
      modelBuilder.Entity<Produto>().Property(p => p.Preco).HasPrecision(18, 2);
    }

  }
}
