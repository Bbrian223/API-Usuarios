using Domain.Interfaces;
using Infrastructure.Interfaces;
using Application.Services;
using Infrastructure.Factories;
using Infrastructure.Repositories;
using Application.models;

namespace API_Usuarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
            builder.Services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            builder.Services.AddScoped<IUserRepository, UsersRepository>();
            builder.Services.AddScoped<IUserServices, UserServices>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
