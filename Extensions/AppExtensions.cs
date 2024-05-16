namespace finance_api.Extensions;

public static class AppExtensions
{
    public static void UseArchitectures(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
    }
}