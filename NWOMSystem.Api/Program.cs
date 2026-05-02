using Microsoft.EntityFrameworkCore;
using NWOMSystem.Application.Services.OrderManagement;
using NWOMSystem.Domain.Entities;


// Importa tus namespaces de las otras capas
using NWOMSystem.Infrastructure;
using NWOMSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection Container
// Injecting Swagger
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// Injecting Repsitories and Services
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); 

//Injecting the AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injecting Use Cases, from the Application Layer, in this case OrderManagement, which will handle the business logic related to orders.
builder.Services.AddScoped<OrderManagement>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter(); 

var app = builder.Build();

app.UseHttpsRedirection(); // Middleware to redirect from HTTP to HTTPS



// 2. Defining the Minimal API Endpoints

/*

Define a route group for Order-related endpoints. This allows you to organize your API routes and apply 
common configurations (like middleware) to all routes within the group. In this case, all routes related 
to orders will be prefixed with "/Order"

*/
var Order = app.MapGroup("/Order");


Order.MapGet("/", async (OrderManagement orderManagement) =>
{
    return await orderManagement.GetAllOrdersAsync();
});


Order.MapGet("/{id}", async (OrderManagement orderManagement, int id) =>
{
    return await orderManagement.GetOrderByIdAsync(id);
});

Order.MapPost("/", async (Order order, OrderManagement orderManagement) =>
{
    await orderManagement.AddOrderAsync(order);
    return Results.Created($"/Order/{order.OrderId}", order);
});

// Los métodos Put y Delete seguirían la misma lógica del tutorial...

app.Run();