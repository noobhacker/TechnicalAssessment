using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Core.Features.Commands.AddFeature;
using TechnicalAssessment.Core.Features.Queries.GetFeature;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Infrastructure.Repositories;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<GetFeatureQueryHandler>()
                .AddScoped<AddFeatureCommandHandler>()
                .AddScoped<IFeatureRepository, FeatureRepository>();


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