# Innolevels_Store
Sistema de gerenciamento de pedidos para uma loja, desenvolvido com ASP.NET.

# Tecnologias Utilizadas
•	ASP.NET Core MVC 8
•	Entity Framework Core
•	SQL Server
•	Bootstrap 5
•	jQuery / JavaScript
•	Autenticação por Cookies

# Arquitetura / Patterns / Boas Práticas
•	Clean Archtecture
•	DDD
•	Dependency Injection
•	Repository
•	Scoped
•	SOLID
•	Clen Code

# Funcionalidades
•	Cadastro de Produtos pelo Administrador
•	Listagem, edição e delete de produtos pelo Administrador
•	Criação e exclusão de pedidos com múltiplos produtos e quantidades pelo Administrador e Usuário Padrão
•	Validações
•	Layout responsivo com Bootstrap
•	Requisições AJAX

# Configurações de Conexão:
Modificar a string de conexão no caminho: Presentation -> Store -> appsettings.json

Substrituir pela sua string de conexão:
"ConnectionStrings": {
  "DefaultConnection": "Data Source=SEUSERVIDOR;Initial Catalog=Innolevels_Store;Integrated Security=False;User ID=sa;Password=SUASENHA;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"
},

Para as Migrations:
Criando Migration: dotnet ef migrations add CriacaoTabelaUsuario --project Infraestructure/Infra/Infra.csproj --startup-project Presentation/Store/Store.csproj

Adicionando ao Banco de Dados:
dotnet ef database update --project Infraestructure/Infra/Infra.csproj --startup-project Presentation/Store/Store.csproj

# Recomendado Inserir alguns produtos a tabela do banco de dados:

INSERT INTO [Innolevels_Store].[dbo].[Produto] ([Nome], [Descricao], [Preco]) VALUES
('Mouse Gamer RGB', 'Mouse com iluminação RGB e 6 botões programáveis.', 129.90),
('Teclado Mecânico', 'Teclado com switches azuis e retroiluminação LED.', 249.99),
('Monitor 24" Full HD', 'Monitor LED 24 polegadas com resolução 1920x1080.', 899.00),
('Headset com Microfone', 'Fone de ouvido com som estéreo e microfone ajustável.', 159.50),
('Webcam Full HD', 'Webcam com resolução 1080p e microfone embutido.', 189.90);
