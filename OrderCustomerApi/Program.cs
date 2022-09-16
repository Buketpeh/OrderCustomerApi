using Microsoft.Extensions.DependencyInjection.Extensions;
using OrderCustomerApi.Data.Context;
using OrderCustomerApi.Data.UnitOfWork;
using OrderCustomerApi.Data.UnitOfWork.Interfaces;
using OrderCustomerApi.Service.Concretes;
using OrderCustomerApi.Service.Interfaces;
using OrderCustomerApi.Service.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped(typeof(DataContext));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ILog, LogService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
