using finance_api.EndPoints.CategoriesEndPoints.AccountEndPoints;
using finance_api.EndPoints.CategoriesEndPoints.CustomerEndPoints;
using finance_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddArchitectures();

var app = builder.Build();

app.UseArchitectures();

app.MapCustomerEndPoints();
app.MapAccountEndPoints();

app.Run();