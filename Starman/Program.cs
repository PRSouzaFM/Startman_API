using Microsoft.Extensions.Configuration;
using Starman.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Starman.Interfaces;
using Starman.Services;

var builder = WebApplication.CreateBuilder(args);
#region [Cors]
builder.Services.AddCors();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StockItemDbContext>(options =>
    options.UseSqlServer(("Server=localhost,1433;Database=nab;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;")));
builder.Services.AddScoped<IStockItemService, StockItemService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c => { c.AllowAnyHeader(); c.AllowAnyMethod(); c.AllowAnyOrigin(); });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
