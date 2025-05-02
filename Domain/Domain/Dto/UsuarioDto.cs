using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dto
{
  public class UsuarioDto
  {
    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 20 caracteres.")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O perfil é obrigatório.")]
    [EnumDataType(typeof(PerfilEnum), ErrorMessage = "Perfil inválido.")]
    public PerfilEnum Perfil { get; set; }

    [Required(ErrorMessage = "A data de criação é obrigatória.")]
    public DateTime DataCriacao { get; set; }
  }
}
