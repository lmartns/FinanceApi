using finance_api.Data;
using Microsoft.EntityFrameworkCore;

public static class BuilderExtensions
{
    public static void AddArchitectures(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<FinanceDbContext>();

        builder.Services.AddDbContext<FinanceDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
    }
}

