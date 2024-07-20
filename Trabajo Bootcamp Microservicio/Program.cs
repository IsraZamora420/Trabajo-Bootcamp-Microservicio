using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICatalogo, CatalogoServices>();
builder.Services.AddScoped<IProducto, ProductoServices>();
builder.Services.AddScoped<IMovimientoCab, MovimientoCabServices>();
builder.Services.AddScoped<IMovimientoDetProd, MovimientoDetProdServices>();
builder.Services.AddScoped<IMovimientoDetPagos, MovimientoDetPagosServices>();
builder.Services.AddScoped<IProveedor, ProveedorServices>();
builder.Services.AddScoped<ICiudad, CiudadServices>();
builder.Services.AddScoped<IUsuarioRol, UsuarioRolServices>();
builder.Services.AddScoped<ITarjetaCredito, TarjetaCreditoServices>();
builder.Services.AddScoped<IOpcion, OpcionServices>();
builder.Services.AddScoped<IUsuarioPermiso, UsuarioPermisoServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BaseErpContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
