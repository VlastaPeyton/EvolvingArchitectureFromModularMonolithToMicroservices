using Common.API.ErrorHandling;
using Common.Infrastructure;
using Fitnet.Module;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddExceptionHandling();
builder.Services.AddCommonInfrastructure();
builder.Services.AddModules(builder.Configuration);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseErrorHandling();
app.RegisterModules();

app.Run();


