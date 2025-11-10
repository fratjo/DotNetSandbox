using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Application.Queries.Users.GetUser;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Users;

public class GetUserRequest
{
    [FromRoute]
    public Guid UserId { get; set; } = Guid.Empty;
}

public class GetUserResponse
{
    public UserDto user { get; set; }
}

public class GetUserEndpoint(IMediator mediator): Endpoint<GetUserRequest, GetUserResponse>
{
    public override void Configure()
    {
        Get("api/users/{UserId}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetUserRequest request, CancellationToken ct)
    {
        var command = new GetUserQuery(request.UserId);
        var result = await mediator.SendAsync(command, ct);
        if (result.IsSuccess && result.Value is not null)
        {
            await Send.OkAsync( new GetUserResponse { user = result.Value});
        }
        else
        {
            await Send.ResultAsync(TypedResults.Problem(result.Message ?? "Failed to create user."));
        }
    }
}
