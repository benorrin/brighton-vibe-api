using BrightonVibe.Application.Services;
using BrightonVibe.Data;
using BrightonVibe.Data.Repositories;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Domain.Services;
using BrightonVibe.Web;
using Microsoft.AspNetCore.Diagnostics;
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

// Add a custom exception handler
builder.Services.AddExceptionHandler<ExceptionHandlerService>();

// Configure CORS to allow any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add dependency injection services
builder.Services.AddDependencyInjectionServices();

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

app.UseExceptionHandler("/error");

app.Map("/error", async (HttpContext context) =>
{
    var exceptionHandler = context.RequestServices.GetRequiredService<IExceptionHandler>();
    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

    await exceptionHandler.TryHandleAsync(context, exception, CancellationToken.None);
});

app.UseStaticFiles();
app.UseRouting();

// Use CORS policy that allows any origin
app.UseCors("AllowAnyOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();