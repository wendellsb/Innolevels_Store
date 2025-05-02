using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
  public class UsuarioRepository : IUsuarioRepository
  {
    private readonly AppDBContext _dbContext;
    public UsuarioRepository(AppDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task AdicionarAsync(UsuarioDto usuario)
    {
      var usuarioBase = new Usuario
      {
        Email = usuario.Email,
        Senha = usuario.Senha,
        Perfil = usuario.Perfil,
        DataCriacao = usuario.DataCriacao
      };
      var usuarioExiste = await ObterPorEmailAsync(usuarioBase.Email);
      if (usuarioExiste != null)
      {
        throw new Exception("Email já cadastrado.");
      }
      _dbContext.Usuarios.Add(usuarioBase);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<Usuario> LoginAsync(UsuarioDto usuario)
    {
      string email = usuario.Email;
      string senha = usuario.Senha;
      return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
    }

    public async Task<Usuario> ObterPorEmailAsync(string email)
    {
      return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }
  }
}
