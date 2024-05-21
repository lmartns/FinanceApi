using finance_api.Data;
using finance_api.DTO;
using finance_api.Entities;

namespace finance_api.EndPoints
{
    public static class FinanceEndPoints
    {
        public static void MapFinanceEndPoints(this WebApplication app)
        {
            var endPointsFinanceCustomer = app.MapGroup("Customer");

            endPointsFinanceCustomer.MapPost("", async (CustomerDTO request, FinanceDbContext context) =>
            {
                var customer = new Customer(request.Name, request.Email)
                {
                    Id = Guid.NewGuid()
                };

                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
            });
        }
    }
}