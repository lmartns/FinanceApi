using finance_api.EndPoints.CategoriesEndPoints.AccountEndPoints;
using finance_api.EndPoints.CategoriesEndPoints.CustomerEndPoints;

namespace finance_api.Extensions;

public static class EndPointExtensions
{
    public static void MapEndPoints(this WebApplication app)
    {
        app.MapCustomerEndPoints();
        app.MapAccountEndPoints();
    }
}