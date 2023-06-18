using TestingSolution.TestProject.Core.ApplicationServices;
using TestingSolution.TestProject.Core.Contracts.Products.DI;
using TestingSolution.TestProject.Infra.Data.SqlDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationCore();
builder.Services.AddStoreInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
