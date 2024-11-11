using Microsoft.EntityFrameworkCore;
using PropertyInventorySystem.API.Mapper;
using PropertyInventorySystem.API.Services;
using PropertyInventorySystem.Infrastructure.Context;
using PropertyInventorySystem.Infrastructure.Repos;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PropertyInventoryDbContext>(option => option.UseSqlServer
           (configuration["ConnectionStrings:DBConnection"]));

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddScoped<IPropertyRepo, PropertyRepo>();
//builder.Services.AddScoped<IPropertyPriceAuditRepo, PropertyPriceAuditRepo>();

builder.Services.AddScoped<IContactRepo, ContactRepo>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IContactService, ContactService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
