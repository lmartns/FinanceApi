namespace finance_api.EndPoints.CategoriesEndPoints.AccountEndPoints
{
    public static class AccountEndPoints
    {
        public static void MapAccountEndPoints(this WebApplication app)
        {
            app.MapGetAllAccountEndpoint();
            app.MapGetAccountByIdEndpoint();
            app.MapPostAccountEndpoint();
            app.MapPutAccountEndpoint();
            app.MapDeleteAccountEndpoint();
        }
    }
}