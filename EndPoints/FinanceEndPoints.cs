namespace finance_api.EndPoints
{
    public static class FinanceEndPoints
    {
        public static void MapFinanceEndPoints(this WebApplication app)
        {
            app.MapGet("/", () => "teste");

            app.MapPost("", () => "");
        }
    }
}