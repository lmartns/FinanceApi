using FinanceApi.Data;

namespace FinanceApi.EndPoints.CategoriesEndPoints.AccountEndPoints;

public static class DeleteAccountEndpoint
{
  public static void MapDeleteAccountEndpoint(this WebApplication app)
  {
    var endPointsAccount = app.MapGroup("Account");

    endPointsAccount.MapDelete("{id:guid}", async (Guid id, FinanceDbContext context) =>
    {
      var account = await context.Accounts.FindAsync(id);
      if (account == null)
      {
        return Results.NotFound("Account not found");
      }

      context.Accounts.Remove(account);
      await context.SaveChangesAsync();

      return Results.NoContent();
    })
    .WithTags("Account")
    .WithName("DeleteAccount")
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status404NotFound)
    .WithDescription("Delete an account. Returns 204 No Content if the account is successfully deleted, or 404 NotFound if no account with the specified ID exists.")
    .WithOpenApi();
  }
}