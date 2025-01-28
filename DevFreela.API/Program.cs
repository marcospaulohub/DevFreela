
using DevFreela.API.ExceptionHandler;
using DevFreela.API.Models;
using DevFreela.API.Services;

namespace DevFreela.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<FreelanceTotalCostConfig>(
                builder.Configuration.GetSection("FreelanceTotalCostConfig")
            );

            // Singleton
            //builder.Services.AddSingleton<IConfigService, ConfigService>();

            // Transient
            //builder.Services.AddTransient<IConfigService, ConfigService>();

            // Scoped
            //builder.Services.AddScoped<IConfigService, ConfigService>();

            builder.Services.AddExceptionHandler<ApiExceptionHandler>();
            builder.Services.AddProblemDetails();


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

            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
