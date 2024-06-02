using finance_api.Data;
using finance_api.DTO.CustomerDtos;
using finance_api.Entities;
using finance_api.Helpers;

namespace finance_api.EndPoints.CategoriesEndPoints.CustomerEndPoints;

public static class PostCustomerEndpoint
{
    public static void MapPostCustomerEndpoint(this WebApplication app)
    {
        var endPointsCustomer = app.MapGroup("Customer");

        endPointsCustomer.MapPost("", async (FinanceDbContext context, CustomerAddDto request) =>
            {
                var customer = new Customer(request.Name, request.Email)
                {
                    Id = IdGenerator.GeneratorNewGuid()
                };

                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
                return Results.Created($"/customers/{customer.Id}", customer);
            }
        );
    }
}