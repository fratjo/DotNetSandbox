using Application.Commands.Users;
using Application.Commands.Users.PatchUser;
using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Users;

public class UpdateUserRequest
{
    [FromRoute]
    public Guid UserId { get; set; } = Guid.Empty;
    public string? Username { get; set; }
    public int? Age { get; set; } 
}

public class UpdateUserEndpoint(IMediator mediator) : Endpoint<UpdateUserRequest>
{

    public override void Configure()
    {
        Patch("api/users/{UserId}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Update User's username";
            s.Params["UserId"] = "user id";
        });
    }
    public override async Task HandleAsync(UpdateUserRequest request, CancellationToken ct)
    {
        var command = new UpdateUserCommand(request.UserId, request.Username, request.Age);
        var result = await mediator.SendAsync(command, ct);
        if (result.IsSuccess)
        {
            await Send.OkAsync();
        }
        else
        {
            await Send.ResultAsync(TypedResults.Problem(result.Message ?? "Failed to create user."));
        }
    }
}
