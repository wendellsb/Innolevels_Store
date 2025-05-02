using Domain.Enums;

namespace Domain.Entities
{
  public class Usuario
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public PerfilEnum Perfil { get; set; }
    public DateTime DataCriacao { get; set; }
  }
}
