using AgiliFoodApplication;
using AgiliFoodDomain.Interfaces;
using AgiliFoodInfrastructure.Context;
using AgiliFoodInfrastructure.Repositories;
using AgiliFoodServices.Services.Interfaces;
using AgiliFoodServices.Services.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISupplierAppService, SupplierAppService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICollaboratorAppService, CollaboratorAppService>();
builder.Services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();


builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(AgiliFoodApplicationAssemblyReference).Assembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AgiliFoodDbContext>
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

app.UseStaticFiles();

app.UseRouting();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:5173")
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
