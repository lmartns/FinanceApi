# Finance API 

Finance Api é um projeto desenvolvido em CSharp, utilizando Dotnet que consiste em uma API para um sistema financeiro.

## Status do projeto

Em desenvolvimento ♻️

## Índice

1. [Pré-requisitos](#pré-requisitos)
2. [Como utilizar](#como-utilizar)
3. [Funcionalidades](#funcionalidades)
   - EndPoints
      - [Customer](#customer)
      - [Account](#account)
5. [Estrutura](#estrutura)

## Pré-requisitos
- [Dotnet EF CLI](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install#get-the-net-core-cli-tools)
- [Dotnet Core](https://dotnet.microsoft.com/en-us/download)
- [Entity Framework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/9.0.0-preview.4.24267.1)
- [Entity Framework Core Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/9.0.0-preview.4.24267.1)
- [Entity Framework Core Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/9.0.0-preview.4.24267.1)
- [Entity Framework Core SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/9.0.0-preview.4.24267.1)

Esse último pacote varia conforme o banco de dados que você esta usando, caso esteja usando o SQL Server, pode usar esse mesmo.

[Pacotes NuGet](https://www.nuget.org/)

## Como utilizar

Após baixar todas as dependências, você precisa primeiro configurar o banco de dados de sua preferência, cada banco utilizará uma [Connection String](https://www.connectionstrings.com/) própria, as strings de conexão estão localizadas no arquivo [appsettings.json](appsettings.json).

Configurado o banco, você irá usar alguns comandos do Entity Framework para criar as tabelas e sincronizar com o banco de dados.

- `dotnet ef migrations add InitialMigration`
- `dotnet ef database update`

Depois dos comandos, somente iniciar o projeto com `dotnet run`, e quando iniciar o localhost, adicione /swagger, por exemplo, https://localhost:1111/swagger.

## Funcionalidades

A API oferece os seguintes endpoints:

### Customer

`GET All`

```json
  {
    "id": "9b79adf6-27e7-4656-b973-04d714fd1341",
    "name": "Alterada",
    "email": "alterada@email.com"
  },
  {
    "id": "8a5cdfc0-7026-4f63-97d3-20bc6090d161",
    "name": "Leo",
    "email": "leo@email.com"
  },
```

`GET By Id`

```json
{
  "id": "8a5cdfc0-7026-4f63-97d3-20bc6090d161",
  "name": "Leo",
  "email": "leonardo@email.com"
}
```

`POST`

###### Schema

```json
{
  "name": "string",
  "email": "string"
}
```

###### Response

```json
{
  "id": "b939396b-86c7-45ba-a0d0-8303752f9e8e",
  "name": "Teste",
  "email": "teste@email.com"
}
```

`PUT`

```json
{
  "id": "b939396b-86c7-45ba-a0d0-8303752f9e8e",
  "name": "Teste alterado",
  "email": "testealterado@email.com"
}
```

`DELETE`

No caso do delete ele ira retornar um [204](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/204).

### Account

`GET ALL`

```json
{
    "id": "56cbdf23-47c9-4f4b-a901-089d11cd0352",
    "accountNumber": 9090,
    "balance": 700,
    "customerId": "9f8279b2-e679-4fab-ab2f-418d640e6926"
  },
  {
    "id": "844f7691-a7d4-4c44-9827-323d80897eb0",
    "accountNumber": 222222,
    "balance": 0,
    "customerId": "9b79adf6-27e7-4656-b973-04d714fd1341"
  },
  {
    "id": "bd5f8b58-76a3-41bd-b088-773743c9462c",
    "accountNumber": 9090,
    "balance": 700,
    "customerId": "8a5cdfc0-7026-4f63-97d3-20bc6090d161"
  },
  {
    "id": "56aa1ff2-bae0-4001-a537-887489f5e72d",
    "accountNumber": 111,
    "balance": 90,
    "customerId": "9b79adf6-27e7-4656-b973-04d714fd1341"
  },
```

`GET ID`

```json
{
  "id": "56cbdf23-47c9-4f4b-a901-089d11cd0352",
  "accountNumber": 9090,
  "balance": 700,
  "customerId": "9f8279b2-e679-4fab-ab2f-418d640e6926"
}
```

`POST`

##### Schema

```json
{
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "accountNumber": 0,
  "balance": 0
}
```

##### Response

```json
{
  "id": "57f2aed5-9dbf-426c-adaa-7cb6d659f65c",
  "accountNumber": 8133763,
  "balance": 500,
  "customerId": "9f8279b2-e679-4fab-ab2f-418d640e6926"
}
```

 `PUT`

```json
{
  "id": "57f2aed5-9dbf-426c-adaa-7cb6d659f65c",
  "accountNumber": 8888,
  "balance": 700,
  "customerId": "9f8279b2-e679-4fab-ab2f-418d640e6926"
}
```

`DELETE`

No caso do delete ele ira retornar um [204](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/204).

### Estrutura 

O projeto Finance API utiliza o design Minimal API, mas, da forma default em que ele é estruturado declarando todos os endpoints no Program.cs fica bem bagunçado. Procurando formas de como poderia estruturar o projeto utilizando Minimal API, encontrei esse [post no Medium](https://marcionizzola.medium.com/organizando-uma-api-constru%C3%ADda-com-minimal-api-no-net-6-96a327a5ad03), me inspirando nesse modelo construí a seguinte estrutura:

```
└── 📁finance-api

    └── .gitignore

    └── appsettings.Development.json

    └── appsettings.json

    └── 📁Data

        └── FinanceDbContext.cs

    └── 📁DTO

        └── 📁AccountAllDtos

            └── AccountAddDto.cs

            └── AccountUpdateDto.cs

        └── 📁CustomerAllDtos

            └── CustomerAddDto.cs

            └── CustomerUpdateDto.cs

    └── 📁EndPoints

        └── 📁CategoriesEndPoints

            └── 📁AccountEndPoints

                └── AccountEndPoints.cs

                └── DeleteAccountEndpoint.cs

                └── GetAllAccountEndpoint.cs

                └── GetByIdAccountEndpoint.cs

                └── PostAccountEndpoint.cs

                └── PutAccountEndpoint.cs

            └── 📁CustomerEndPoints

                └── CustomerEndPoints.cs

                └── DeleteCustomerEndpoint.cs

                └── GetAllCustomerEndpoint.cs

                └── GetByIdCustomerEndpoint.cs

                └── PostCustomerEndpoint.cs

                └── PutCustomerEndpoint.cs

    └── 📁Entities

        └── Account.cs

        └── Customers.cs

        └── Operation.cs

        └── Transaction.cs

    └── 📁Extensions

        └── AppExtensions.cs

        └── BuilderExtensions.cs

        └── EndPointExtensions.cs

    └── 📁Helpers

        └── IdGenerator.cs

    └── Program.cs

    └── README.md
```

Consiste basicamente no uso de Extension para fazer a extensão das classes `WebApplication e WebApplicationBuilder`, dessa forma preciso somente
adicionar o método de extensão `MapEndPoints` ao Program.cs, ficando
organizado e com o nosso Program.cs limpo:

```c#
using finance_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddArchitectures();

var app = builder.Build();

app.UseArchitectures();

app.MapEndPoints();

app.Run();
```

Lembrando que a estrutura do projeto final pode ficar um pouco diferente de quando foi documentado.


## Contribuição

Contribuições são bem-vindas! Se você deseja contribuir para o projeto, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`).
3. Faça commit das suas alterações (`git commit -am 'Adiciona nova feature'`).
4. Envie para a branch principal (`git push origin feature/nova-feature`).
5. Abra um Pull Request.


## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
