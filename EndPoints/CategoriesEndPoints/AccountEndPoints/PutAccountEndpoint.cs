using finance_api.Data;
using finance_api.DTO.AccountDtos;

namespace finance_api.EndPoints.CategoriesEndPoints.AccountEndPoints;

public static class PutAccountDelete
{
  public static void MapPutAccountEndpoint(this WebApplication app)
  {
    var endPointsAccount = app.MapGroup("Account");

    endPointsAccount.MapPut("{id:guid}", async (Guid id, AccountUpdateDto request, FinanceDbContext context) =>
    {
      var account = await context.Accounts.FindAsync(id);
      if (account == null)
      {
        return Results.NotFound("Account not found");
      }

      account.AccountNumber = request.AccountNumber;
      account.Balance = request.Balance;
      await context.SaveChangesAsync();
      return Results.Ok(account);
    });
  }
}