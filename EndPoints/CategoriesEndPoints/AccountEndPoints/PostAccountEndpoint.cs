using finance_api.Data;
using finance_api.DTO.AccountAllDtos;
using finance_api.Entities;
using finance_api.Helpers;

namespace finance_api.EndPoints.CategoriesEndPoints.AccountEndPoints;

public static class PostAccountEndpoint
{
  public static void MapPostAccountEndpoint(this WebApplication app)
  {
    var endPointsAccount = app.MapGroup("Account");
    endPointsAccount.MapPost("", async (AccountAddDto request, FinanceDbContext context) =>
    {
      var customer = await context.Customers.FindAsync(request.CustomerId);

      if (customer == null)
      {
        return Results.NotFound("Customer not found");
      }

      var newId = IdGenerator.GeneratorNewGuid();

      var account = new Account(request.AccountNumber, request.CustomerId, request.Balance)
      {
        Id = newId
      };

      await context.Accounts.AddAsync(account);
      await context.SaveChangesAsync();

      return Results.Created($"/accounts/{account.Id}", account);
    });
  }
}