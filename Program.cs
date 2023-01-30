using ProyectoMVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EscuelaContext>(options => options.UseInMemoryDatabase("testDB"));

var app = builder.Build();

using(var scope=app.Services.CreateScope()){
    var serv=scope.ServiceProvider;
    try
    {
        var contex=serv.GetRequiredService<EscuelaContext>();
        contex.Database.EnsureCreated();
    }
    catch (System.Exception)
    {
        throw;
    }

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //define el view incial del app
    //en este caso busca en la carpeta Home de vista un archivo llamado Index
    pattern: "{controller=Escuela}/{action=Inicio}/{id?}");

app.Run();
