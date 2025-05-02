using Application.Service;
using Application.Validations;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
  [Authorize(Roles = "Admin")]
  public class ProdutoController : Controller
  {
    private readonly ProdutoService _produtoService;
    public ProdutoController(ProdutoService produtoService)
    {
      _produtoService = produtoService;
    }

    public async Task<IActionResult> Index()
    {
      var produto = await _produtoService.ListarProdutoAsync();
      return View(produto);
    }

    public IActionResult Adicionar()
    {
      return View();
    }

    [HttpPost]
    public async Task<JsonResult> Adicionar([FromForm] Produto produto)
    {
      try
      {
        ModelState.Remove("Id");

        var erro = Validation.ValidarProduto(produto);
        if (erro != null)
        {
          return Json(new { sucesso = false, mensagem = $"Erro: {erro}" });
        }

        if (ModelState.IsValid)
        {
          await _produtoService.AdicionarProdutoAsync(produto);
          return Json(new { sucesso = true });
        }
        return Json(new { sucesso = false, mensagem = "Dados inválidos." });
      }
      catch (Exception ex)
      {
        return Json(new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
      }
    }

    [HttpPost]
    public async Task<JsonResult> Editar([FromForm] Produto produto)
    {
      try
      {
        var erro = Validation.ValidarProduto(produto);
        if (erro != null)
        {
          return Json(new { sucesso = false, mensagem = $"Erro: {erro}" });
        }

        if (ModelState.IsValid)
        {
          await _produtoService.AtualizarProdutoAsync(produto);
          return Json(new { sucesso = true });
        }
        return Json(new { sucesso = false, mensagem = "Dados inválidos." });
      }
      catch (Exception ex)
      {
        return Json(new { sucesso = false, mensagem = $"Erro: {ex.Message}" });
      }
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(int id)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _produtoService.RemoverProdutoAsync(id);
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
