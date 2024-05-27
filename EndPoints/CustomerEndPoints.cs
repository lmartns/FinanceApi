using finance_api.Data;
using finance_api.DTO.CustomerAllDtos;
using finance_api.Entities;
using finance_api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace finance_api.EndPoints
{
    public static class CustomerEndPoints
    {

        public static void MapCustomerEndPoints(this WebApplication app)
        {
            var endPointsCustomer = app.MapGroup("Customer");
            var newId = IdGenerator.GeneratorNewGuid();

            endPointsCustomer.MapGet("", async (FinanceDbContext context) =>
                {
                    var customers = await context.Customers.ToListAsync();
                    return Results.Ok(customers);
                }

            );

            endPointsCustomer.MapGet("{Id:guid}", async (Guid Id, FinanceDbContext context) =>
                {
                    var customer = await context.Customers.FindAsync(Id);
                    return Results.Ok(customer);
                }
            );

            endPointsCustomer.MapPost("", async (CustomerAddDto request, FinanceDbContext context) =>
                {
                    var customer = new Customer(request.Name, request.Email)
                    {
                        Id = newId
                    };

                    await context.Customers.AddAsync(customer);
                    await context.SaveChangesAsync();
                    return Results.Created($"/customers/{customer.Id}", customer);
                }
            );

            endPointsCustomer.MapPut(
                "{Id:guid}",
                async (Guid Id, CustomerUpdateDto request, FinanceDbContext context) =>
                {
                    var customer = await context.Customers.FindAsync(Id);
                    if (customer != null)
                    {
                        customer.Name = request.Name;
                        customer.Email = request.Email;
                        await context.SaveChangesAsync();
                    }
                    return Results.Ok(customer);
                }
            );

            endPointsCustomer.MapDelete(
                "{Id:guid}",
                async (Guid Id, FinanceDbContext context) =>
                {
                    var customer = await context.Customers.FindAsync(Id);
                    if (customer != null)
                    {
                        context.Customers.Remove(customer);
                        await context.SaveChangesAsync();
                    }
                    return Results.NoContent();
                }
            );
        }
    }
}

