using AutoMapper;
using DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Services.Classes;
using Services.Interfaces;
using ThAmCo.Order_Management.WebAPI.Repositories.Classes;
using ThAmCo.Order_Management.WebAPI.Repositories.Interfaces;
using ThAmCo.Order_Management.WebAPI.Services.Classes;
using ThAmCo.Order_Management.WebAPI.Services.Interfaces;
using ThAmCo.Profiles.Mapper;

namespace ThAmCo.Order_Management.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }
                );
            });

            // Configure JWT authentication.
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = _configuration["Jwt:Authority"];
                options.Audience = _configuration["Jwt:Audience"];
            });


            // Configure the database context
            var connectionString = _configuration.GetConnectionString("OrdersConnectionsString");
            services.AddDbContext<OrdersContext>(options =>
                options.UseSqlServer(connectionString));


            services.AddAutoMapper(cfg => cfg.AddProfile<OrderProfile>());

            // Add controllers
            services.AddControllers();

            // Add services
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IGuidUtility, GuidUtility>();

            // Add API endpoint exploration and Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add the file provider
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                // EnsureCreated in development
                using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<OrdersContext>();
                dbContext.Database.EnsureCreated();

                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                // Apply migrations in production
                using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<OrdersContext>();
                dbContext.Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            //JWT Bearer authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
