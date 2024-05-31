namespace finance_api.EndPoints.CategoriesEndPoints.CustomerEndPoints
{
    public static class CustomerEndPoints
    {
        public static void MapCustomerEndPoints(this WebApplication app)
        {
            app.MapGetAllCustomerEndpoint();
            app.MapGetCustomerByIdEndpoint();
            app.MapPostCustomerEndpoint();
            app.MapPutCustomerEndpoint();
            app.MapDeleteCustomerEndpoint();
        }
    }
}