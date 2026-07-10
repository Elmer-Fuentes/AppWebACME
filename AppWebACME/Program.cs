using AppWebACME.Data;
using Microsoft.EntityFrameworkCore;

namespace AppWebACME
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // INICIO INYECCION DE DEPENDENCIAS DEL PROYECTO DE ACCESO A DATOS EN EL CONTEXT DEL PROYECTO WEB
            var connectionString = builder.Configuration
            .GetConnectionString("ACMEContext")
                ?? throw new InvalidOperationException(
                 "No se encontró la cadena de conexión 'ACMEContext'.");

            builder.Services.AddDbContext<ACMEContext>(options =>
                options.UseSqlServer(connectionString));

            //FIN INYECCION DE DEPENDENCIAS DEL PROYECTO DE ACCESO A DATOS EN EL CONTEXT DEL PROYECTO WEB

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
