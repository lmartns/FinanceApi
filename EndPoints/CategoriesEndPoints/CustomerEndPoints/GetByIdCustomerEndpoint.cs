using FinanceApi.Data;

namespace FinanceApi.EndPoints.CategoriesEndPoints.CustomerEndPoints;

public static class GetByIdCustomerEndpoint
{
    public static void MapGetCustomerByIdEndpoint(this WebApplication app)
    {
        var endPointsCustomer = app.MapGroup("Customer");

        endPointsCustomer.MapGet("{id}", async (FinanceDbContext context, Guid id) =>
            {
                var customer = await context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(customer);
            }
        );
    }
}