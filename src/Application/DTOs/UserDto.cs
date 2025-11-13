namespace Application.DTOs.UserDto;

public class CreateUserDto
{
    public string Username { get; set; } = string.Empty;
    public int Age { get; set; }
}

public record UserIdDto(Guid id);

public record UserDto(string username, int age);

public static class UserDtoExtensions
{
    public static UserDto ToUserDto(this Domain.Entities.User user)
    {
        return new UserDto(user.Username, user.Age);
    }
}
