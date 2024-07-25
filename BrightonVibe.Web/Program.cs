using BrightonVibe.Application.Services;
using BrightonVibe.Data;
using BrightonVibe.Data.Repositories;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

// Configure PostgreSQL database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection for application services and domain services
builder.Services.AddScoped<AccountApplicationService>();
builder.Services.AddScoped<VenueApplicationService>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IVenueService, VenueService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IVenueRepository, VenueRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrightonVibe API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root of the application
    });
}
else
{
    // Handle errors in production
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();