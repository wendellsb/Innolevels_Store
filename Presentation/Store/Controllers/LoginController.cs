using Application.Service;
using Application.Validations;
using Domain.Dto;
using Domain.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Store.Controllers
{
  public class LoginController : Controller
  {
    private readonly UsuarioService _usuarioService;
    public LoginController(UsuarioService usuarioService)
    {
      _usuarioService = usuarioService;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Cadastro()
    {
      return View();
    }

    public IActionResult AccessDenied()
    {
      return View("AccessDenied");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public async Task<IActionResult> Index(string email, string senha, string returnUrl = null)
    {
      try
      {
        var erro = Validation.ValidarLogin(email, senha);
        if (erro != null)
        {
          TempData["MensagemErro"] = erro;
          return View();
        }

        var usuario = new UsuarioDto
        {
          Email = email,
          Senha = senha
        };

        var usuarioLogado = await _usuarioService.EfetuarLoginAsync(usuario);

        if (usuarioLogado == null)
        {
          TempData["MensagemErro"] = "Email ou senha inválidos.";
          return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuarioLogado.Email),
            new Claim(ClaimTypes.Role, usuarioLogado.Perfil.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
          return Redirect(returnUrl);

        if (usuarioLogado.Perfil == PerfilEnum.Admin)
        {
          return RedirectToAction("Index", "Produto");
        }
        else
        {
          return RedirectToAction("Index", "Pedido");
        }
      }
      catch (Exception ex)
      {
        TempData["MensagemErro"] = $"Erro ao efetuar o LogIn: {ex.Message}";
        return View();
      }
    }


    [HttpPost]
    public async Task<IActionResult> Cadastro(string email, string senha, int perfil)
    {
      try
      {
        var erro = Validation.ValidarCadastro(email, senha, perfil);
        if (erro != null)
        {
          TempData["MensagemErro"] = erro;
          return View();
        }

        var usuario = new UsuarioDto
        {
          Email = email,
          Senha = senha,
          Perfil = (PerfilEnum)perfil,
          DataCriacao = DateTime.UtcNow
        };

        await _usuarioService.AdicionarUsuarioAsync(usuario);

        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
        return RedirectToAction("Index", "Login");
      }
      catch (Exception ex)
      {
        TempData["MensagemErro"] = $"Erro ao cadastrar: {ex.Message}";
        return View();
      }
    }
  }
}
