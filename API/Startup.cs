using System;
using System.Text;
using System.Threading.Tasks;
using API.Middleware;
using API.SignalR;
using AutoMapper;
using Core;
using Core.Interfaces;
using Core.UserProfiles;
using Domain;
using FluentValidation.AspNetCore;
using Infrastructure.PhotoUpload;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Database Context
            services.AddDbContext<DataContext>(opt =>
            {
                // Setup lazy loading proxies
                opt.UseLazyLoadingProxies();
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add SignalR
            services.AddSignalR();

            // Add MediatR
            services.AddMediatR(typeof(InitCore).Assembly);

            // Add AutoMapper
            services.AddAutoMapper(typeof(InitCore).Assembly);

            // Add Cors to the API
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("WWW-Authenticate")
                            .WithOrigins("http://localhost:3000").AllowCredentials();
                    });
            });

            // Add API Controllers
            services.AddControllers(opt =>
                {
                    // This causes all endpoints to require authorization
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    opt.Filters.Add(new AuthorizeFilter(policy));
                }
            ).AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<InitCore>(); });

            // Add ASP.NET Identity
            var builder = services.AddIdentityCore<AppUser>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<DataContext>();
            identityBuilder.AddSignInManager<SignInManager<AppUser>>();

            // Setup Authorization Requirements For Paths
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsActivityHost",
                    policy => { policy.Requirements.Add(new IsHostAuthRequirement()); });
            });

            services.AddTransient<IAuthorizationHandler, IsHostAuthRequirementHandler>();

            // Setup JWT Token Authentication
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                // Set up JWT Bearer to allow access to token from SignalR
                opt.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;

                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chat"))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            // Setup JWT Generator
            services.AddScoped<IJwtGenerator, JwtGenerator>();

            // Setup HTTP Context username extractor and profile reader
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IProfileReader, ProfileReader>();

            // Setup Cloudinary Photo Upload
            services.Configure<CloudinarySettings>(Configuration.GetSection("Cloudinary"));
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            // app.UseHttpsRedirection();

            // Middleware: Allow ASP.NET to route to the API controllers
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            // Middleware: Map controller endpoints into the API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
