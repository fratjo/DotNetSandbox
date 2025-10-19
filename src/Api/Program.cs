using Infrastructure.Mediator;
using Application.Common.Mediator;
using Application.Common.Mediator.Query;
using Application.Queries.Users.GetCurrentUser;
using Domain.Common;
using Domain.Entities;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

// Dependencies injection
builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddScoped<IQueryHandler<GetCurrentUserQuery, Result<User>>, GetCurrentUserHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();
app.UseSwaggerGen();

await app.RunAsync();