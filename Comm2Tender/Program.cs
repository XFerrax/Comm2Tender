using Comm2Tender.Data;
using Comm2Tender.Logic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<ILogicService, LogicService>();


builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer") //"Bearer"
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ////ValidateIssuer = true,
                ////ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ////ValidateAudience = true,
                ////ValidAudience = "TenderSelectionClient",
                //ValidateLifetime = true,
                //ValidateIssuerSigningKey = true,

                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        }
    );



builder.Services.AddAuthorization();

builder.Services.AddCors(options => 
    options.AddPolicy(name: "FrontSite", 
                builder => builder
                    .SetIsOriginAllowed(isOriginAllowed: _ => true)
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

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("FrontSite");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
