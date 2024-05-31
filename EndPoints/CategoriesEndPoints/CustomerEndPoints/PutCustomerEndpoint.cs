using finance_api.Data;
using finance_api.DTO.CustomerAllDtos;

namespace finance_api.EndPoints.CategoriesEndPoints.CustomerEndPoints;

public static class PutCustomerEndpoint
{
    public static void MapPutCustomerEndpoint(this WebApplication app)
    {
        var endPointsCustomer = app.MapGroup("Customer");

        endPointsCustomer.MapPut("{id}", async (FinanceDbContext context, Guid id, CustomerUpdateDto request) =>
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return Results.NotFound();
            }

            customer.Name = request.Name;
            customer.Email = request.Email;

            await context.SaveChangesAsync();
            return Results.Ok(customer);
        });
    }
}