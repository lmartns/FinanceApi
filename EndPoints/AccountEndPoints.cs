using finance_api.Data;
using finance_api.DTO.AccountAllDtos;
using finance_api.Entities;
using finance_api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace finance_api.EndPoints;

public static class AccountEndPoints
{
    public static void MapAccountEndPoints(this WebApplication app)
    {
        var endPointsAccount = app.MapGroup("Account");

        endPointsAccount.MapGet("", async (FinanceDbContext context) =>
        {
            var accounts = await context.Accounts.ToListAsync();
            return Results.Ok(accounts);
        });

        endPointsAccount.MapGet("{id:guid}", async (Guid id, FinanceDbContext context) =>
        {
            var account = await context.Accounts.FindAsync(id);
            if (account == null)
            {
                return Results.NotFound("Account not found");
            }

            return Results.Ok(account);
        });

        endPointsAccount.MapPost("", async (AccountAddDto request, FinanceDbContext context) =>
        {
            var customer = await context.Customers.FindAsync(request.CustomerId);

            if (customer == null)
            {
                return Results.NotFound("Customer not found");
            }

            var newId = IdGenerator.GeneratorNewGuid();

            var account = new Account(request.AccountNumber, request.CustomerId)
            {
                Id = newId
            };

            await context.Accounts.AddAsync(account);
            await context.SaveChangesAsync();

            return Results.Created($"/accounts/{account.Id}", account);
        });

        endPointsAccount.MapPut("{id:guid}", async (Guid id, AccountUpdateDto request, FinanceDbContext context) =>
            {
                var account = await context.Accounts.FindAsync(id);
                if (account == null)
                {
                    return Results.NotFound("Account not found");
                }

                account.AccountNumber = request.AccountNumber;
                await context.SaveChangesAsync();

                return Results.Ok(account);
            }
        );

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
            }
        );
    }
}