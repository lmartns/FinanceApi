using FinanceApi.Data;

public static class DeleteCustomerEndpoint
{
    public static void MapDeleteCustomerEndpoint(this WebApplication app)
    {
        var endPointsCustomer = app.MapGroup("Customer");

        endPointsCustomer.MapDelete("{id}", async (FinanceDbContext context, Guid id) =>
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return Results.NotFound();
            }

            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            return Results.Ok();
        });
    }
}