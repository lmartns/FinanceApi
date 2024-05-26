using finance_api.Data;
using finance_api.DTO.AccountAllDtos;
using finance_api.Entities;
using finance_api.Helpers;

namespace finance_api.EndPoints
{
    public static class AccountEndPoints
    {
        public static void MapAccountEndPoints(this WebApplication app)
        {
            var endPointsAccount = app.MapGroup("Account");

            endPointsAccount.MapPost("", async (AccountAddDto request, FinanceDbContext context) =>
            {
                var customer = await context.Customers.FindAsync(request.CustomerId);

                if (customer == null)
                {
                    // Retornar NotFound quando o cliente não for encontrado
                    return Results.NotFound("Customer not found");
                }

                // Geração de um novo Id para a conta dentro do escopo do MapPost
                var newId = IdGenerator.GeneratorNewGuid();

                var account = new Account(request.AccountNumber, request.CustomerId)
                {
                    Id = newId
                };

                await context.Accounts.AddAsync(account);
                await context.SaveChangesAsync();

                // Retornar Created com a URL do novo recurso criado
                return Results.Created($"/accounts/{account.Id}", account);
            });
        }
    }
}
