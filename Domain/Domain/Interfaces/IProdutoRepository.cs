using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IProdutoRepository
  {
    Task<List<Produto>> ListarAsync();
    Task<Produto> ObterPorIdAsync(int id);
    Task AdicionarAsync(Produto produto);
    Task AtualizarAsync(Produto produto);
    Task RemoverAsync(int id);
  }
}
