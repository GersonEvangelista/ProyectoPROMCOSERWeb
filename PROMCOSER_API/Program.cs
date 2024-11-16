using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using PROMCOSER_DOMAIN.CORE.Services;
using PROMCOSER_DOMAIN.Infrastructure.Repositories;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Repositories;
using UESAN.PROMCOSER_DOMAIN.DOMAIN.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<PromcoserContext> //Importar using
    (options => options.UseSqlServer(cnx)); //Importar using 

builder.Services.AddTransient<IPersonalRepository, PersonalRepository>();
builder.Services.AddTransient<IPersonalService, PersonalService>();
builder.Services.AddTransient<IMaquinariaRepository, MaquinariaRepository>();

builder.Services.AddSharedInfrastructure(_config);

builder.Services.AddControllers();

//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder//.WithOrigins("https://www.miempresa.com/frontend")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

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
app.UseCors();
app.MapControllers();

app.Run();
