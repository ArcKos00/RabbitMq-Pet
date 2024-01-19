using System.Reflection;
using Banking.Application.Interfaces;
using Banking.Application.Services;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.Interfaces;
using Infrastructure.Ioc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(Program))));
builder.Services.RegisterServices();
builder.Services.AddDbContext<BankingDbContext>(opts =>
    opts.UseNpgsql(builder.Configuration.GetConnectionString("BankingDbConnection")));
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

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
await app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<BankingDbContext>().Database.MigrateAsync();

app.Run();
