using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Services;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();

builder.Services.AddScoped<IEmpresa, EmpresaService>();
builder.Services.AddScoped<IStock, StockService>();
builder.Services.AddScoped<IBodega, BodegaService>();
builder.Services.AddScoped<IStock, StockService>();
builder.Services.AddScoped<ISucursal, SucursalService>();
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
builder.Services.AddScoped<IUsuarioAutenticacion, UsuarioAutenticacionService>();

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

//Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();




