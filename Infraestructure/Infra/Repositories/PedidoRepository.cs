using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
  public class PedidoRepository : IPedidoRepository
  {
    private readonly AppDBContext _dbContext;
    public PedidoRepository(AppDBContext appDbContext)
    {
      _dbContext = appDbContext;
    }

    public async Task AdicionarAsync(Pedido pedido)
    {
      _dbContext.Pedido.Add(pedido);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Pedido>> ListarAsync()
    {
      return await _dbContext.Pedido.Include(p => p.Itens).ThenInclude(i => i.Produto).ToListAsync();
    }

    public async Task<Pedido> ObterPorIdAsync(int id)
    {
      return await _dbContext.Pedido.Include(p => p.Itens).ThenInclude(i => i.Produto).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task RemoverAsync(int id)
    {
      var pedido = await _dbContext.Pedido.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);

      if (pedido == null) throw new Exception("Pedido não encontrado.");

      _dbContext.ItemPedido.RemoveRange(pedido.Itens);
      _dbContext.Pedido.Remove(pedido);

      await _dbContext.SaveChangesAsync();
    }
  }
}
