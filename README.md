# BookHub

## Descrição
Uma aplicação web para criar, visualizar, atualizar e deletar anotações textuais.

## Configuração do Ambiente
- Versão do .NET Framework: 8.0
- Editor: VSCode
- Banco de Dados: MySQL

## Como Executar
1. Abra um novo terminal no VSCode em: Cabeçalho -> Terminal -> Novo Terminal ou pressione CRTL+SHIFT+'.
2. Digite `dotnet run`.

## Pacotes Necessários
1. Os seguintes pacotes precisam estar incluidos no arquivo BookHub.csproj:
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.VisualStudio.Web.CodeGenerators.Mvc
- Pomelo.EntityFrameworkCore.MySql.Design
- Pomelo.EntityFrameworkCore.MySql

## Funcionalidades
- Este projeto é uma aplicação de gerenciamento de anotações textuais, incorporando operações CRUD (Criar, Ler, Atualizar e Deletar). As principais funcionalidades incluem:
1. Criar Anotação:
Permite aos usuários criar novas anotações textuais através da interface da aplicação.
2. Visualizar Anotação:
Disponibiliza a capacidade de visualizar anotações previamente criadas na interface da aplicação.
3. Atualizar Anotação:
Oferece a funcionalidade de atualizar anotações existentes, permitindo aos usuários modificar o conteúdo conforme necessário.
4. Deletar Anotação:
Permite aos usuários excluir anotações que não são mais necessárias.
Autenticação com Asp.Net Identity:
5. Utiliza o Asp.Net Identity para fornecer autenticação à aplicação.
Protege áreas restritas, como as operações de criação, edição e exclusão de anotações, garantindo que apenas usuários autenticados possam realizar essas ações.

## Desafios
- Durante o desenvolvimento, um dos desafios principais enfrentados foi a demora no processamento da máquina utilizada. Isso impactou significativamente o tempo de desenvolvimento e limitou o escopo do projeto, além de invibializar o ambiente de desenvolvimento no Visual Studio.
