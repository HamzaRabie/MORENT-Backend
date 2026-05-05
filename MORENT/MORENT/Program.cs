
using Microsoft.EntityFrameworkCore;
using MORENT.Context;
using MORENT.Repository.Implementations;
using MORENT.Repository.Interfaces;
using MORENT.Services.Implementations;
using MORENT.Services.Interfaces;

namespace MORENT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //   builder.Services.AddOpenApi();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("any",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:4200") 
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(opt =>
                        opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));



            builder.Services.AddScoped<IBookingRepo,BookingRepo>();
            builder.Services.AddScoped<IBookingService,BookingService>();
            builder.Services.AddScoped<ICarRepo,CarRepo>();
            builder.Services.AddScoped<ICarService,CarService>();

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("any");

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
