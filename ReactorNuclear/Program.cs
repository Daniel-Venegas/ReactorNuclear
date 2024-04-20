using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Repositores;
using ReactorNuclear.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<REDbContext>(options => options.UseSqlServer(conString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add repositories
builder.Services.AddScoped<ITipoVRepository, TipoVRepository>();
builder.Services.AddScoped<ITipoVService, TipoVService>();

builder.Services.AddScoped<IDetalleDRepository , DetalleDRepository>();
builder.Services.AddScoped<IDetalleDService, DetalleDService>();

builder.Services.AddScoped<IDispRepository, DispRepository>();
builder.Services.AddScoped<IDispService, DispService>();

builder.Services.AddScoped<IMonitoreoXDispoRepository, MonitoreoXDispoRepository>();
builder.Services.AddScoped<IMonitoreoXDispoService, MonitoreoXDispoService>();

builder.Services.AddScoped<IVarMoRepository, VarMoRepository>();
builder.Services.AddScoped<IVarMoService, VarMoService>();

builder.Services.AddScoped<ICaracteristicasRepository, CaracteristicasRepository>();
builder.Services.AddScoped<ICaracteristicasService, CaracteristicasService>();

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
