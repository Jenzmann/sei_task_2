
using SEI4.Controllers;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace SEI4
{
    public class Program
    {
        public static List<City> Cities = new List<City> 
            {
                new City()
        {
            Id = Guid.NewGuid().ToString(),
                    Country = "DE",
                    Latitude = "1234",
                    Longtitude = "43245",
                    Name = "Marbeck",
                    PostalCode = "46325"
                },
                new City()
        {
            Id = Guid.NewGuid().ToString(),
                    Country = "DE",
                    Latitude = "1234d",
                    Longtitude = "4245",
                    Name = "Gescher",
                    PostalCode = "48712"
                },
                new City()
        {
            Id = Guid.NewGuid().ToString(),
                    Country = "DE",
                    Latitude = "1234",
                    Longtitude = "43245",
                    Name = "Coesfeld",
                    PostalCode = "43267"
                },
                new City()
        {
            Id = Guid.NewGuid().ToString(),
                    Country = "DE",
                    Latitude = "1234",
                    Longtitude = "43245",
                    Name = "Berlin",
                    PostalCode = "12345"
                },
                new City()
        {
            Id = Guid.NewGuid().ToString(),
                    Country = "DE",
                    Latitude = "1234",
                    Longtitude = "43245",
                    Name = "Hamburg",
                    PostalCode = "25645"
                },
                new City()
        {
            Id = Guid.NewGuid().ToString(),
                    Country = "EN",
                    Latitude = "1234",
                    Longtitude = "43245",
                    Name = "london",
                    PostalCode = "test2331"
                }
    };
    public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

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
