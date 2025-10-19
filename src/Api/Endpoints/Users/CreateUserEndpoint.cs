using Application.Commands.Users;
using Application.Common.Mediator;
using Application.DTOs.UserDto;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Endpoints.Users;

public class CreateUserEndpoint(IMediator mediator) : Endpoint<CreateUserCommand, UserIdDto>
{
    public override void Configure()
    {
        Post("api/users");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Create User";
            s.Description = "Creates a new user in the system.";
            s.Responses[201] = "Returns the newly created user's ID.";
            s.Responses[400] = "Bad Request - The request was invalid.";
        });
    }
    public override async Task HandleAsync(CreateUserCommand command, CancellationToken ct)
    {
        var result = await mediator.SendAsync(command, ct);
        if (result.IsSuccess && result.Value is not null)
        {
            await Send.OkAsync(result.Value);
        }
        else
        {
            await Send.ResultAsync(TypedResults.Problem(result.Message ?? "Failed to create user."));
        }
    }
}

