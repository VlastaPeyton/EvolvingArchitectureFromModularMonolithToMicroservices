using InitialArchitecture.Common.Clock;
using InitialArchitecture.Common.ErrorHandling;
using InitialArchitecture.Common.Events.EventBus;
using InitialArchitecture.Common.Validation;
using InitialArchitecture.Contracts;
using InitialArchitecture.Offers;
using InitialArchitecture.Passes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <= SwashBuckle.AspNetCore NuGet

builder.Services.AddExceptionHandling(); 
builder.Services.AddEventBus();
builder.Services.AddRequestValidations();
builder.Services.AddClock();
builder.Services.AddContracts(builder.Configuration);
builder.Services.AddOffers(builder.Configuration);
builder.Services.AddPasses(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{   // <= SwashBuckle.AspNetCore NuGet
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandling(); 
app.UseContracts();
app.UseOffers();
app.UsePasses();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapContracts();
app.MapPasses(); 

app.Run();

