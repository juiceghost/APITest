using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

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

        //app.UseHttpsRedirection();

        app.UseAuthorization();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        {
            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast");

        app.MapPost("/product", (ProductModel product) =>
        {
            // Denna endpoint ska bara gå att komma åt om du lyckats autentisera dig
            //string MyLocation = httpContext.Request.Query["location"].ToString();
            var response = SQLServerDataAccess.AddProduct(product);


            return response;
        })
        .WithName("AddProduct");

        app.MapGet("/product", (HttpContext httpContext) =>
        {
            // Denna endpoint ska bara gå att komma åt om du lyckats autentisera dig
            //string MyLocation = httpContext.Request.Query["location"].ToString();
            //var response = SQLServerDataAccess.AddProduct("Macbook Air", "Bestest computer evah");
            var response = SQLServerDataAccess.GetProducts();

            return response;
        })
        .WithName("GetProducts");

        app.MapGet("/krille", (HttpContext httpContext) =>
        {
            // Denna endpoint ska bara gå att komma åt om du lyckats autentisera dig
            string MyLocation = httpContext.Request.Query["location"].ToString();
            var response = new KrilleModel
            {
                id = 5,
                name = "DaMan!",
                description = "Whatever",
                location = MyLocation
            };

            return response;
        })
        .WithName("GetKrille");

        app.MapPost("/login2", (UserModel loginAttempt) =>
        {
            // Denna endpoint låter användaren autentisera sig mot vårt API.
            // Dvs låter användaren logga in.
            // Användaren måste göra ett POST request till denna endpoint
            // username måste vara Krille
            // password måste vara Janbanan123

            

            Console.WriteLine($"Username from Insomnia: {loginAttempt.username}, password: {loginAttempt.password}");
            // here after you can play as you like :)
            //return await Task.FromResult<string>(postData);

            var response = new LoginResponse { };

            if (loginAttempt.username == "Krille" && loginAttempt.password == "Janbanan123")
            {
                response.code = 200;
                response.message = "Login successful";
                return loginAttempt.LoginSuccess();
            }

            response.code = 401;
            response.message = "Username or password incorrect";
            return loginAttempt.LoginFailed();

        })
        .WithName("Login2");
        /*
        app.MapPost("/login", async (HttpContext httpContext) =>
        {
            // Denna endpoint låter användaren autentisera sig mot vårt API.
            // Dvs låter användaren logga in.
            // Användaren måste göra ett POST request till denna endpoint
            // username måste vara Krille
            // password måste vara Janbanan123

            var body = new StreamReader(httpContext.Request.Body);
            string postData = await body.ReadToEndAsync();
            UserModel loginUser = JsonSerializer.Deserialize<UserModel>(postData) ?? new UserModel { };

            Console.WriteLine($"Username from Insomnia: {loginUser.username}, password: {loginUser.password}");
            // here after you can play as you like :)
            //return await Task.FromResult<string>(postData);

            var response = new LoginResponse { };

            if (loginUser.username == "Krille" && loginUser.password == "Janbanan123")
            {
                response.code = 200;
                response.message = "Login successful";
                return response;
            }

            response.code = 401;
            response.message = "Username or password incorrect";
            return Result.Unauthorized(response);

        })
        .WithName("Login");
        */

        app.Run();
    }
}

