using Comm2Tender.Data;
using Comm2Tender.Logic;
using Comm2Tender.Logic.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IDataService, DataService>();
        builder.Services.AddScoped<ILogicService, LogicService>();


        builder.Services.AddControllers();

        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(
                options =>
                {
                    byte[] hash;
                    using (SHA512 shaM = SHA512.Create())
                    {
                        hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
                    }

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(hash),
                    };
                }
            );

        builder.Services.AddAuthorization();

        builder.Services.AddCors(options =>
            options.AddPolicy(name: "FrontSite",
                        builder => builder
                            .WithOrigins("http://localhost:5000")
                            //.SetIsOriginAllowed(isOriginAllowed: _ => true)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("FrontSite");

        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}