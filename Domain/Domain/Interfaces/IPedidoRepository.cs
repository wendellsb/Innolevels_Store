using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IPedidoRepository
  {
    Task<List<Pedido>> ListarAsync();
    Task<Pedido> ObterPorIdAsync(int id);
    Task AdicionarAsync(Pedido pedido);
    Task RemoverAsync(int id);
  }
}
