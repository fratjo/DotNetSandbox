using Application.Commands.Users;
using Application.Common.Mediator;
using Application.Common.Mediator.Query;
using Application.Queries.Users.GetCurrentUser;
using Domain.Common;
using Domain.Entities;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure.Mediator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

// Injection of the Mediator service
builder.Services.AddScoped<IMediator, Mediator>();

// Register all command handlers
builder.Services.AddScoped<Application.Common.Mediator.Command.ICommandHandler<CreateUserCommand, Result<Guid>>, CreateUserCommandHandler>();

// Register all query handlers
builder.Services.AddScoped<IQueryHandler<GetCurrentUserQuery, Result<User>>, GetCurrentUserQueryHandler>();


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