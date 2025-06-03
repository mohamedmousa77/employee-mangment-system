using EmployeeMangment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
namespace EmployeeMangment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDBContext>(
                options => options.UseInMemoryDatabase("EmployeeDB")
            );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Adjust the origin as needed
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });

            });

            var app = builder.Build();

            app.UseCors("MyCors");

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
