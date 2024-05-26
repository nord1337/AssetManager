using Google.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockApi.Data;
using System.Reflection;

namespace StockApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddDbContext<TestDbContext>(opt => opt.UseInMemoryDatabase(builder.Configuration.GetConnectionString("TestDb")));
            builder.Services.AddInvestApiClient((_, settings) => settings.AccessToken = builder.Configuration.GetValue<string>("TinkoffToken"));
            builder.Services.AddAutoMapper(conf => conf.AddMaps(Assembly.GetExecutingAssembly()));

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));

            var app = builder.Build();

            SeedTestData(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corsapp");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void SeedTestData(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TestDbContext>();
            SeedTestDataHelper.SeedAsync(context);
        }
    }
}