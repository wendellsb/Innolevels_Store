using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Service
{
  public class UsuarioService
  {
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
      _usuarioRepository = usuarioRepository;
    }

    public async Task AdicionarUsuarioAsync(UsuarioDto usuario)
    {
      await _usuarioRepository.AdicionarAsync(usuario);
    }

    public async Task<Usuario> EfetuarLoginAsync(UsuarioDto usuario)
    {
      return await _usuarioRepository.LoginAsync(usuario);
    }
  }
}
