using Application.Common.Mediator;
using Application.Queries.Users.GetCurrentUser;
using Domain.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace WebApi.Endpoints.Users;

public class GetCurrentUserEndpoint(IMediator mediator) : EndpointWithoutRequest<Results<Ok<User>, NotFound<string>, BadRequest<string>, UnauthorizedHttpResult, ProblemDetails>>
{
    public override void Configure()
    {
        Get("api/users/me");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Get Current User";
            s.Description = "Retrieves the currently authenticated user's details.";
            s.Responses[200] = "Returns the current user's details.";
            s.Responses[401] = "Unauthorized - The user is not authenticated.";
            s.Responses[404] = "Not Found - The user does not exist.";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await mediator.SendAsync(new GetCurrentUserQuery(), ct);
        if (result.IsSuccess && result.Value is not null)
        {
            await Send.ResultAsync(TypedResults.Ok(result.Value));
        }
        else
        {
            switch (result.ErrorType)
            {
                case Domain.Common.ErrorType.NotFound:
                    await Send.ResultAsync(TypedResults.NotFound(result.Message ?? "User not found."));
                    break;
                case Domain.Common.ErrorType.Unauthorized:
                    await Send.ResultAsync(TypedResults.Unauthorized());
                    break;
                case Domain.Common.ErrorType.BadRequest:
                    await Send.ResultAsync(TypedResults.BadRequest(result.Message ?? "Bad Request"));
                    break;
                default:
                    await Send.ResultAsync(TypedResults.Problem(
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "An unexpected error occurred.",
                        detail: result.Message));
                    break;
            }
        }
    }
}