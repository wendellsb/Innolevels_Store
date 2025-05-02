using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
  public class ProdutoRepository : IProdutoRepository
  {
    private readonly AppDBContext _dbContext;
    public ProdutoRepository(AppDBContext appDbContext)
    {
      _dbContext = appDbContext;
    }

    public async Task AdicionarAsync(Produto produto)
    {
      _dbContext.Produto.Add(produto);
      await _dbContext.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Produto produto)
    {
      _dbContext.Produto.Update(produto);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Produto>> ListarAsync()
    {
      return await _dbContext.Produto.ToListAsync();
    }

    public async Task<Produto> ObterPorIdAsync(int id)
    {
      return await _dbContext.Produto.FindAsync(id);
    }

    public async Task RemoverAsync(int id)
    {
      var produto = await _dbContext.Produto.FindAsync(id);
      _dbContext.Produto.Remove(produto);
      await _dbContext.SaveChangesAsync();
    }
  }
}
