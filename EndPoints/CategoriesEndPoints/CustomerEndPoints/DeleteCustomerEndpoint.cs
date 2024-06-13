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
            return Results.NoContent();
        })
        .WithTags("Customer")
        .WithName("DeleteCustomer")
        .WithDescription("Delete a customer. Returns 204 No Content if the customer is successfully deleted, or 404 NotFound if no customer with the specified ID exists.")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();
    }
}