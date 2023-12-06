using DataAccess.Contexts;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerMapperProfile, CustomerMapperProfile>();
builder.Services.AddScoped<IUnitOfWorkCustomer, UnitOfWorkCustomer>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductMapperProfile, ProductMapperProfile>();
builder.Services.AddScoped<IUnitOfWorkProduct, UnitOfWorkProduct>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderMapperProfile, OrderMapperProfile>();
builder.Services.AddScoped<IOrderProductMapperProfile, OrderProductMapperProfile>();
builder.Services.AddScoped<IUnitOfWorkOrder, UnitOfWorkOrder>();

builder.Services.AddScoped<ICustomerOrderMapper, CustomerOrderMapper>();

builder.Services.AddDbContext<ShopContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ShopDb");
    options.UseSqlServer(connectionString);
});

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
