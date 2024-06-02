using FinanceApi.Data;

namespace FinanceApi.EndPoints.CategoriesEndPoints.AccountEndPoints;

public static class GetByIdAccountEndpoint
{
  public static void MapGetAccountByIdEndpoint(this WebApplication app)
  {
    var endPointsAccount = app.MapGroup("Account");
    endPointsAccount.MapGet("{id}", async (FinanceDbContext context, Guid id) =>
    {
      var account = await context.Accounts.FindAsync(id);
      if (account == null)
      {
        return Results.NotFound();
      }
      return Results.Ok(account);
    });
  }
}