using Microsoft.EntityFrameworkCore;
using PROMCOSER_API___Rol__Ubigeo.Core.Interfaces;
using PROMCOSER_API___Rol__Ubigeo.Core.Services;
using PROMCOSER_API___Rol__Ubigeo.Infraestructure.Data;
using PROMCOSER_API___Rol__Ubigeo.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<PromcoserContext>
    (options => options.UseSqlServer(cnx));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<IUbigeoRepository, UbigeoResository>();
builder.Services.AddTransient<IRolService, RolService>();
builder.Services.AddTransient<IUbigeoService, UbigeoService>();
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
