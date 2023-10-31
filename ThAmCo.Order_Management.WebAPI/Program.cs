using Microsoft.EntityFrameworkCore;
using ThAmCo.Orders.DataContext;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Determine the environment
var environment = builder.Environment;

// Use the same connection string for both environments
var connectionString = configuration.GetConnectionString("ConnectionString");

// Add services to the container.
builder.Services.AddDbContext<OrdersContext>(options =>
    options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllers();








// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (environment.IsDevelopment())
{
    // EnsureCreated in development
    using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<OrdersContext>();
    dbContext.Database.EnsureCreated();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Apply migrations in production
    using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<OrdersContext>();
    dbContext.Database.Migrate();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
