using EventsProject.Data;
using Microsoft.EntityFrameworkCore;

namespace EventsProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173") // Allow your frontend's URL
                              .AllowCredentials()  // Allow credentials (cookies, authorization headers)
                              .AllowAnyHeader()    // Allow any headers
                              .AllowAnyMethod();   // Allow any HTTP method
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddDbContext<EventsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
