using Microsoft.EntityFrameworkCore;
using RepositorioDTO_EF.Data;
using RepositorioDTO_EF.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextoDB>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddScoped<ProductoRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
