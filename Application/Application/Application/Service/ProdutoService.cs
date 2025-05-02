using Domain.Entities;
using Domain.Interfaces;

namespace Application.Service
{
  public class ProdutoService
  {
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
      _produtoRepository = produtoRepository;
    }

    public async Task<List<Produto>> ListarProdutoAsync()
    {
      return await _produtoRepository.ListarAsync();
    }

    public async Task AdicionarProdutoAsync(Produto produto)
    {
      await _produtoRepository.AdicionarAsync(produto);
    }

    public async Task AtualizarProdutoAsync(Produto produto)
    {
      await _produtoRepository.AtualizarAsync(produto);
    }

    public async Task<Produto> ObterProdutoPorIdAsync(int id)
    {
      return await _produtoRepository.ObterPorIdAsync(id);
    }

    public async Task RemoverProdutoAsync(int id)
    {
      await _produtoRepository.RemoverAsync(id);
    }
  }
}
