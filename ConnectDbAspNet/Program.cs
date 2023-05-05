using ConnectDbAspNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectDbAspNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<SchoolContext>(options =>
            {
                // Ändra till din lokala databas och kör update-database i package manager console
                options.UseSqlServer("Server=(localdb)\\jdlocal;Database=SchoolDB;Trusted_Connection=True;");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            app.Run();
        }
    }
}