using Application.Commands.Users.CreateUser;
using Application.Common.Mediator;
using Application.DTOs.UserDto;
using FastEndpoints;

namespace Api.Endpoints.Users;

public class CreateUserRequest
{
    public CreateUserDto Dto { get; set; } = new();
}

public class CreateUserResponse
{
    public UserIdDto UserId { get; set; } = null!;
}

public class CreateUserEndpoint(IMediator mediator) : Endpoint<CreateUserRequest, CreateUserResponse>
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
            s.Responses[409] = "Conflict - Already existing user";
        });
    }
    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        var command = new CreateUserCommand(request.Dto.Username, request.Dto.Age);
        var result = await mediator.SendAsync(command, ct);
        if (result.IsSuccess && result.Value is not null)
        {
            await Send.OkAsync(new CreateUserResponse { UserId = result.Value });
        }
        else
        {
            await Send.ResultAsync(TypedResults.Problem(result.Message ?? "Failed to create user.", null, (int)result.ErrorType));
        }
    }
}

