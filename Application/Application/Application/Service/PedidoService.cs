using Domain.Entities;
using Domain.Interfaces;

namespace Application.Service
{
  public class PedidoService
  {
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoRepository _produtoRepository;
    public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
    {
      _pedidoRepository = pedidoRepository;
      _produtoRepository = produtoRepository;
    }

    public async Task CriarPedidoAsync(Dictionary<int, int> produtosComQuantidade)
    {
      var pedido = new Pedido
      {
        DataCriacao = DateTime.Now,
        Itens = new List<ItemPedido>()
      };
      foreach (var item in produtosComQuantidade)
      {
        var produto = await _produtoRepository.ObterPorIdAsync(item.Key);
        if (produto == null)
          throw new Exception();

        pedido.Itens.Add(new ItemPedido
        {
          ProdudoId = produto.Id,
          Produto = produto,
          Quantidade = item.Value
        });
      }

      await _pedidoRepository.AdicionarAsync(pedido);
    }

    public async Task<List<Pedido>> ListarPedidoAsync()
    {
      return await _pedidoRepository.ListarAsync();
    }

    public async Task<Pedido> ObterPorIdAsync(int id)
    {
      return await _pedidoRepository.ObterPorIdAsync(id);
    }

    public async Task RemoverPedidoAsync(int id)
    {
      await _pedidoRepository.RemoverAsync(id);
    }
  }
}
