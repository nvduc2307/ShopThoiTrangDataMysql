using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.IRepositories;
using ShopThoiTrang.BackEnd.Repositories;
using ShopThoiTrang.BackEnd.UnitOfWorks;
using ShopThoiTrang.BackEnd.Utils;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionstring = configuration.GetConnectionString("mysql");
// Add services to the container.
builder.ConfigAuthentication(configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainDbContext>(options => {
    options.UseMySQL(connectionstring);
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
