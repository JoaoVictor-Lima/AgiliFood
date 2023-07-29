using AgiliFoodApplication;
using AgiliFoodInfrastructure.Context;
using AgiliFoodInfrastructure.Repositories;
using AgiliFoodServices.Services;
using AgiliFoodServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISupplierAppService, SupplierAppService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();


builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(AgiliFoodApplicationAssemblyReference).Assembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AgileFoodDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
