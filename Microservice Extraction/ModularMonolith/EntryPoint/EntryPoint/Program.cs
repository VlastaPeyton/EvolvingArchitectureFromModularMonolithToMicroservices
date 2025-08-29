using Common.API.ErrorHandling;
using Common.Infrastructure.Clock;
using EntryPoint;
using Offers.API;
using Passes.API;
using Reports;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();

// Uvezem NuGet packages koje sam napravio od Common.sln projekata
builder.Services.AddClock();
builder.Services.AddPasses(builder.Configuration, Module.Passes);
builder.Services.AddOffers(builder.Configuration, Module.Offers);
builder.Services.AddReports(builder.Configuration, Module.Reports);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseErrorHandling();

app.RegisterPasses(Module.Passes);
app.RegistersOffers(Module.Offers);
app.RegisterReports(Module.Reports);

app.Run();


