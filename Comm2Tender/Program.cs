using Comm2Tender.Contexts;
using Comm2Tender.Repositories;
using Comm2Tender.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Comm2Tender.Logic;
using System.IdentityModel.Tokens.Jwt;
using Comm2Tender.Logic.Enum;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using Comm2Tender.Data;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                //ValidateIssuer = true,
                //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                //ValidateAudience = true,
                //ValidAudience = "TenderSelectionClient",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
            };
        }
    ) ;
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddAuthorization();
// Add services to the container.

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddSingleton<ILogicService, LogicService>();

builder.Services.AddControllers();

//builder.Services.AddDbContext<Comm2TenderDataBaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options => 
    options.AddPolicy(name: "FrontSite", 
                builder => builder
                    .SetIsOriginAllowed(isOriginAllowed: _ => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()));

var app = builder.Build();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("FrontSite");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
