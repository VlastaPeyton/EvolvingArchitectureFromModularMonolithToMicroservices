using InitialArchitecture.Common.Clock;
using InitialArchitecture.Common.ErrorHandling;
using InitialArchitecture.Common.Events.EventBus;
using InitialArchitecture.Common.Validation;
using InitialArchitecture.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <= SwashBuckle.AspNetCore NuGet

builder.Services.AddExceptionHandling(); 
builder.Services.AddEventBus();
builder.Services.AddRequestValidations();
builder.Services.AddContracts(builder.Configuration);
builder.Services.AddClock();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{   // <= SwashBuckle.AspNetCore NuGet
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandling(); 
app.UseContracts();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapContracts();

app.Run();

