using Application.Service;
using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
  [Authorize(Roles = "Admin, Padrao")]
  public class PedidoController : Controller
  {
    private readonly PedidoService _pedidoService;
    private readonly ProdutoService _produtoService;

    public PedidoController(PedidoService pedidoService, ProdutoService produtoService)
    {
      _pedidoService = pedidoService;
      _produtoService = produtoService;
    }

    public async Task<IActionResult> Index()
    {
      var pedidos = await _pedidoService.ListarPedidoAsync();

      return View(pedidos);
    }

    public async Task<IActionResult> Adicionar()
    {
      var produtos = await _produtoService.ListarProdutoAsync();
      ViewBag.Produtos = produtos;
      return View(produtos);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(PedidoDto pedidoDto)
    {
      var produtosSelecionados = pedidoDto.Itens
          .Where(i => i.Quantidade > 0)
          .ToDictionary(i => i.ProdutoId, i => i.Quantidade);

      if (!produtosSelecionados.Any())
      {
        ModelState.AddModelError(string.Empty, "Você deve selecionar pelo menos um produto com quantidade maior que zero.");


        var produtos = await _produtoService.ListarProdutoAsync();
        ViewBag.Produtos = produtos;

        return View(pedidoDto);
      }

      await _pedidoService.CriarPedidoAsync(produtosSelecionados);

      return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(int id)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _pedidoService.RemoverPedidoAsync(id);
          return Json(new { sucesso = true });
        }
        return Json(new { sucesso = false, mensagem = "Dados inválidos." });
      }
      catch (Exception ex)
      {
        return Json(new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
      }
    }

  }
}
