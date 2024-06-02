using FinanceApi.EndPoints.CategoriesEndPoints.AccountEndPoints;
using FinanceApi.EndPoints.CategoriesEndPoints.CustomerEndPoints;

namespace FinanceApi.Extensions;

public static class EndPointExtensions
{
    public static void MapEndPoints(this WebApplication app)
    {
        app.MapCustomerEndPoints();
        app.MapAccountEndPoints();
    }
}