using finance_api.Data;
using finance_api.Entities;
using finance_api.Services;

namespace finance_api.EndPoints
{
    public static class FinanceEndPoints
    {
        public static void MapFinanceEndPoints(this WebApplication app)
        {
            var endPointsFinance = app.MapGroup("Customer");

            endPointsFinance.MapPost("", async (AddCustomerRequest request, FinanceDbContext context) =>
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