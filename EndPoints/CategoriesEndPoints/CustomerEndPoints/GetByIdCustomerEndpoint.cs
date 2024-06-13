using FinanceApi.Data;
using FinanceApi.Entities;

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
        )
        .WithTags("Customer")
        .WithName("GetCustomerById")
        .WithDescription("Get a customer by id")
        .Produces<Customer>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();
    }
}