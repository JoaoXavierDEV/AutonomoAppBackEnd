//using NetDevPack.Security.JwtSigningCredentials;
using AutonomoApp.Identidade.Data;
using AutonomoApp.Identidade.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.

namespace AutonomoApp.Identidade.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret);

            //services.AddJwksManager(options => options.Algorithm = Algorithm.ES256)
            //    .PersistKeysToDatabaseStore<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString($"{builder.Environment.EnvironmentName}")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = JwtSecurityKey.Create(appSettingsSection.Get<AppTokenSettings>().Secret),
                    //IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(appSettingsSection.Get<AppTokenSettings>().Secret)),
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.ValidoEm,
                    ValidAudience = appSettings.Emissor,

                    //ValidateLifetime = true,
                    //ClockSkew = System.TimeSpan.Zero
                };
            });

            return services;
        }
    }
}

#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.