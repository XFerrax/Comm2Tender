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
builder.Services.AddTransient<IÑustomsDutyRepository, ÑustomsDutyRepository>();
builder.Services.AddTransient<IDictClaimRepository, DictClaimRepository>();
builder.Services.AddTransient<IDictContragentRepository, DictContragentRepository>();
builder.Services.AddTransient<IEconomicEffectRepository, EconomicEffectRepository>();
builder.Services.AddTransient<IEconomicEffectVarRepository, EconomicEffectVarRepository>();
builder.Services.AddTransient<IInterestRateRepository, InterestRateRepository>();
builder.Services.AddTransient<IListClaimRepository, ListClaimRepository>();
builder.Services.AddTransient<ILogTenderRepository, LogTenderRepostory>();
builder.Services.AddTransient<IPosTenderRepository, PosTenderRepository>();
builder.Services.AddTransient<IVarContragentOfTenderRepository, VarContragentOfTenderRepository>();

builder.Services.AddTransient<ICalculationService, CalculationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();
