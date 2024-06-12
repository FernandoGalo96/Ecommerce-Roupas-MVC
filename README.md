
Criação da Home Page:

Desenvolvi um banner para a página inicial.
Ajustei o título da Home Page para melhorar a apresentação visual.
Configuração do Entity Framework:

Configurei o Entity Framework e defini as entidades necessárias.
Conexão com o Banco de Dados:

Estabeleci a conexão com o banco de dados MySQL usando o MySQL Workbench.
Geração de Migrations:

Criei migrations para popular inicialmente as tabelas de Categorias e, posteriormente, as tabelas de Camisetas.
Criação do Repositório e Interfaces:

Implementei o repositório e as interfaces necessárias.
Configurei a injeção de dependência do DbContext para facilitar a comunicação com o banco de dados através de LINQ.
Configuração da Injeção de Dependência:

Adicionei os repositórios ao serviço de injeção de dependência no Program.cs usando AddTransient.
Desenvolvimento do ViewModel:

Criei o ViewModel para representar as Camisetas na aplicação.
Implementação de Partial Views:

Criei Partial Views para reutilizar o código nas diferentes views do projeto.
Ajuste no Controller das Camisetas:

Configurei o controller das camisetas para exibir as camisetas adequadamente nas views.
Adição de Navegação:

Adicionei uma aba de navegação para as camisetas no site.
Configuração de HttpContext e Sessions:

Configurei o uso do HttpContext, das sessions e do MemoryCache no Program.cs.
Desenvolvimento das Entidades do Carrinho de Compras:

Adicionei as entidades necessárias para a funcionalidade do carrinho de compras.
Geração de Migration do Carrinho de Compras:

Criei uma migration específica para o carrinho de compras.
Implementação de Métodos do Carrinho de Compras:

Desenvolvi métodos para adicionar itens, remover itens, obter itens do carrinho e limpar o carrinho na classe CarrinhoCompra.
Configuração do Carrinho de Compras:

Configurei a injeção de dependência para a classe CarrinhoCompra usando AddScoped no Program.cs.
Criação do Controller do Carrinho de Compras:

Implementei o CarrinhoCompraController com métodos para:
Obter o carrinho de compras.
Adicionar itens ao carrinho.
Remover itens do carrinho.
Obter itens do carrinho de compras.
Limpar o carrinho.
Obter o total do carrinho de compras.
Adições na View e Controller das Camisetas:

Na view de camisetas, adicionei um link no nome da camiseta com a action Details do controlador CamisetaController para mostrar mais informações.
Adicionei botões para adicionar ao carrinho e continuar comprando (voltando à action list).
No controller de camisetas, implementei um método de busca e adicionei uma barra de pesquisa na view layout para pesquisa de produtos por nome.
Implementação do Pedido:

Criei as classes Pedidos e PedidosDetalhe, adicionei as data annotations, gerei as migrations e subi ao banco de dados.
Adicionei a classe PedidoController com os métodos Checkout (GET e POST).
Criei a view de checkout para preenchimento do formulário de conclusão do pedido e a view CheckoutCompleto para mostrar a conclusão do pedido.
