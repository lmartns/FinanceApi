using finance_api.Data;
using Microsoft.EntityFrameworkCore;

namespace finance_api.EndPoints.CategoriesEndPoints.CustomerEndPoints;

public static class GetAllCustomerEndpoint
{
    public static void MapGetAllCustomerEndpoint(this WebApplication app)
    {
        var endPointsCustomer = app.MapGroup("Customer");

        endPointsCustomer.MapGet("", async (FinanceDbContext context) =>
            {
                var customers = await context.Customers.ToListAsync();
                return Results.Ok(customers);
            }
        );
    }
}