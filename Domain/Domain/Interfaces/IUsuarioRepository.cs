using Domain.Dto;
using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IUsuarioRepository
  {
    Task<Usuario> LoginAsync(UsuarioDto usuario);
    Task<Usuario> ObterPorEmailAsync(string email);
    Task AdicionarAsync(UsuarioDto usuario);
  }
}
