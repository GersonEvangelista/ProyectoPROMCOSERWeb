using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.Data;
using PROMCOSER_DOMAIN.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _config = builder.Configuration;

var cnx = _config.GetConnectionString("DevConnection");

builder.Services

    .AddDbContext<PromcoserContext>

    (options => options.UseSqlServer(cnx));
builder.Services.AddTransient<IMaquinariaRepository, MaquinariaRepository>();

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