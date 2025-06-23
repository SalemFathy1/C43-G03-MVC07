using Domain.Exceptions;
using E_Commerce.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<StoredDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<IDbInitializer, DbInitializer>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IServiceManager, ServiceManager>();
        builder.Services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = (context) =>
            {
                var errors = context.ModelState.Where(m => m.Value.Errors.Any())
                .Select(m => new ValidationError
                {
                    Field = m.Key,
                    Errors = m.Value.Errors.Select(error => error.ErrorMessage)
                });
                var response = new ValidationErrorResponse { ValidationErrors = errors };

                return new BadRequestObjectResult(response);
            };
        });

        var app = builder.Build();
        await InitializeDbAsync(app);
        app.UseMiddleware<CustomExceptionHadlerMiddleware>();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStaticFiles();   // Middleware
        app.UseHttpsRedirection();

        //app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    public static async Task InitializeDbAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope(); // To dispose it
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        await dbInitializer.InitializeAsync();
    }
}