using Kata.Booking.Core.Business;
using Kata.Booking.Web.Api.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var swaggerEnabled = true;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterServices();
builder.Services.AddEndpointsApiExplorer();
if (swaggerEnabled)
{
    builder.Services.AddSwaggerGen(opts =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });
}

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
//Disable the model state in the Validate methods
    options.SuppressModelStateInvalidFilter = true;
    //Use HttpResponseException that is caught by the ErrorMiddlware
    options.InvalidModelStateResponseFactory = context => {
        var problemDetails = new ValidationProblemDetails(context.ModelState);
        throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, problemDetails.Errors);
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ErrorMiddleware>();

app.Run();
