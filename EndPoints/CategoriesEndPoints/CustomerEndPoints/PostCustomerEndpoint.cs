using FinanceApi.Data;
using FinanceApi.DTO.CustomerDtos;
using FinanceApi.Entities;
using FinanceApi.Helpers;

namespace FinanceApi.EndPoints.CategoriesEndPoints.CustomerEndPoints;

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
        )
        .WithTags("Customer")
        .WithName("PostCustomer")
        .WithDescription("Create a new customer")
        .Produces<Customer>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();
    }
}