using System;
using domain.interfaces;
using infrastructure.data;
using infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// handle http requests and responses through controllers in ASP.NET Core
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DefaultAzureCredential + DbContext class with the .NET dependency injection container.
string connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connection);
        options.AddInterceptors(new AzureIdentityAuthenticationDbConnectionInterceptor());
    });


//register the UserRepository and IUserRepository in your dependency injection container
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserResourcesRepository, UserResourcesRepository>();
builder.Services.AddScoped<IWheelSegmentRepository, WheelSegmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // this means that everytime i run the application locally, it will make sure the db is updated
    using var serviceScope = app.Services.CreateScope();
    var Services = serviceScope.ServiceProvider;
    var dbContext = Services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
    //
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// maps incoming http requests to appropriate controller and action method
app.MapControllers();

app.Run();