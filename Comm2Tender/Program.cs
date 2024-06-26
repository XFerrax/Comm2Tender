using Comm2Tender.Contexts;
using Comm2Tender.Repositories;
using Comm2Tender.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<Comm2TenderDataBaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IAdditionalConditionRepository, AdditionalConditionRepostory>();
builder.Services.AddTransient<I�ustomsDutyRepository, �ustomsDutyRepository>();
builder.Services.AddTransient<IDictClaimRepository, DictClaimRepository>();
builder.Services.AddTransient<IContragentRepository, ContragentRepository>();
builder.Services.AddTransient<IEconomicEffectRepository, EconomicEffectRepository>();
builder.Services.AddTransient<IEconomicEffectVarRepository, EconomicEffectVarRepository>();
builder.Services.AddTransient<IInterestRateRepository, InterestRateRepository>();
builder.Services.AddTransient<IListClaimRepository, ListClaimRepository>();
builder.Services.AddTransient<ILogTenderRepository, LogTenderRepostory>();
builder.Services.AddTransient<IPosTenderRepository, PosTenderRepository>();
builder.Services.AddTransient<IVarContragentOfTenderRepository, VarContragentOfTenderRepository>();

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

app.UseCors("FrontSite");

app.MapControllers();

app.Run();
