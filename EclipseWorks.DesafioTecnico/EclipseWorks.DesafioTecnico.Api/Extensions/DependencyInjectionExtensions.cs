using EclipseWorks.DesafioTecnico.Api.Middlewares;
using EclipseWorks.DesafioTecnico.Domain.Constantes;
using EclipseWorks.DesafioTecnico.Repository.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Text;


namespace EclipseWorks.DesafioTecnico.Api.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterApiDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddLogging();

            services.AddMvc()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services
            .ConfigureSwaggerRoute()
            .ConfigureCors()
                .RegisterEntityFrameworkContext(config)
            .AddMvcSecurity();

            return services;
        }

        private static IServiceCollection AddMvcSecurity(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;

                    x.Audience = "eclipseworks";
                    x.ClaimsIssuer = "eclipseworks";

                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SigningCredentialsConfiguration("eclipseworks_ApplicationSecurity.SecretKey").Key
                    };

                    x.TokenValidationParameters.ValidIssuers = new[]
                    {
                        "eclipseworks"
                    };
                });

            services.AddAuthorizationBuilder()
                .AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build())
                .AddPolicy("PerfilAcessoPolicy", policy =>
                {
                    policy.RequireClaim("PerfilAcesso", "Gerente");
                });

            return services;
        }

        private static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("*",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        private static IServiceCollection ConfigureSwaggerRoute(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EclipseWorks.DesafioTecnico", Version = "v1" });

                options.IgnoreObsoleteActions();
                options.IgnoreObsoleteProperties();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme,Id = "Bearer"}
                    },
                    new List<string>()
                }
            });
            });

            return services;
        }


        public static WebApplication RegisterSwaggerRoute(this WebApplication app)
        {
            app.UseSwagger()
               .UseSwaggerUI();

            return app;
        }

        public static WebApplication RegisterMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            return app;
        }

        private static IServiceCollection RegisterEntityFrameworkContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")).ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
            return services;
        }

        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            return app;
        }
    }
}


/*
 https://jwt.io/#debugger-io?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJCMEE3OEY3MS0zRDQ4LTRDQjAtOEFENC02RUFCMTc0NDU5MjgiLCJlbWFpbCI6InVzZXIwMUB0ZXN0ZS5jb20uYnIiLCJ1bmlxdWVfbmFtZSI6IlVzZXIgMDEiLCJleHAiOjE3MDQzNDYwNzUsImlzcyI6ImVjbGlwc2V3b3JrcyIsImF1ZCI6ImVjbGlwc2V3b3JrcyJ9.x6QGm9N03Ke8s56KZprpL01TttY-fyFmS3It_nU6dHo
 */