using EmployeeMangment.Data;
using EmployeeMangment.Repositories;
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
                    builder.WithOrigins("http://localhost:4200") 
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });

            });

            // adding the employee repository into the DI (Dipendency Injection)
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(); 

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    config.RoutePrefix = string.Empty; // TO redirect me to swagger UI directly

                });
            }

            app.UseCors("MyCors");

            app.MapControllers();

            app.Run();
        }
    }
}
