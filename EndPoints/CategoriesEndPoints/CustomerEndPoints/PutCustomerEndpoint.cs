using FinanceApi.Data;
using FinanceApi.DTO.CustomerDtos;
using FinanceApi.Entities;

namespace FinanceApi.EndPoints.CategoriesEndPoints.CustomerEndPoints;

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
        })
        .WithTags("Customer")
        .WithName("PutCustomer")
        .WithDescription("Update a customer")
        .Produces<Customer>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();
    }
}