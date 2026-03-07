using VehicleDataAPI.Clients;
using VehicleDataAPI.Services;

namespace VehicleDataAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddHttpClient<IVehicleApiClient, VehicleApiClient>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();

            // Add Swagger/OpenAPI services
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