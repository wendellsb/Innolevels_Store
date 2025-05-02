using Domain.Entities;

namespace Application.Validations
{
  public class Validation
  {
    public static string ValidarLogin(string email, string senha)
    {
      if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
        return "Email e Senha são obrigatórios para LogIn.";

      if (!EmailValido(email))
        return "Formato de e-mail inválido.";

      if (senha.Length < 6)
        return "A senha deve ter pelo menos 6 caracteres.";

      if (senha.Length > 20)
        return "A senha não pode exceder 20 caracteres.";

      return null;
    }

    public static string ValidarCadastro(string email, string senha, int perfil)
    {
      if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) || perfil == 0)
        return "Email e Senha são obrigatórios para cadastro.";

      if (!EmailValido(email))
        return "Formato de e-mail inválido.";

      if (senha.Length < 6)
        return "A senha deve ter pelo menos 6 caracteres.";

      if (senha.Length > 20)
        return "A senha não pode exceder 20 caracteres.";

      return null;
    }

    public static string ValidarProduto(Produto produto)
    {
      if (produto == null)
        return "Produto não pode ser nulo.";

      // Nome
      if (string.IsNullOrWhiteSpace(produto.Nome))
        return "O nome do produto é obrigatório.";

      if (produto.Nome.Length < 3)
        return "O nome do produto deve ter no mínimo 3 caracteres.";

      if (produto.Nome.Length > 100)
        return "O nome do produto deve ter no máximo 100 caracteres.";

      // Descrição
      if (string.IsNullOrWhiteSpace(produto.Descricao))
        return "A descrição do produto é obrigatória.";

      if (produto.Descricao.Length < 5)
        return "A descrição do produto deve ter no mínimo 5 caracteres.";

      if (produto.Descricao.Length > 255)
        return "A descrição do produto deve ter no máximo 255 caracteres.";

      // Preço
      if (produto.Preco <= 0)
        return "O preço do produto deve ser maior que zero.";

      if (produto.Preco > 999999.99m)
        return "O preço do produto não pode ultrapassar R$999.999,99.";

      return null;
    }

    private static bool EmailValido(string email)
    {
      if (string.IsNullOrWhiteSpace(email))
        return false;

      try
      {
        email = email.Trim();
        var endereco = new System.Net.Mail.MailAddress(email);
        return endereco.Address.Equals(email, StringComparison.OrdinalIgnoreCase);
      }
      catch
      {
        return false;
      }
    }
  }
}
