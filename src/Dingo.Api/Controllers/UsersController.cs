using Dingo.Api.Domain;
using Dingo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;

    [HttpPost]
    public IActionResult Create(CreateUserRequest request)
    {
        //Create the user
        //mapping to internal presentation
        var user = request.ToDomain();

        //invoking the use case
        _userService.CreateUser(user);

        //mapping to internal representation
        //Return 201 Created user response
        return CreatedAtAction(
            nameof(Get),
            new { userId = user.Id },
            UserResponse.FromDomain(user));
    }

    [HttpGet]
    public IActionResult Get([FromQuery] QueryObjects queryObjects)
    {

        var query = _userService.AsQueryable();

        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling((double)totalCount / queryObjects.PageSize);
        query = query.Skip((queryObjects.Page - 1) * queryObjects.PageSize).Take(queryObjects.PageSize);

        var users = query.ToList();

        return Ok(new PagedUserResponse(totalCount, totalPages, queryObjects.Page, queryObjects.PageSize, UserResponse.FromDomain(users)));
    }

    [HttpGet("{userId:guid}")]
    public IActionResult Get(Guid userId)
    {
        //Get the user
        var user = _userService.Get(userId);

        //Return 200 ok user response
        return user is null ? Problem(statusCode: StatusCodes.Status404NotFound, detail: "User not found") : Ok(UserResponse.FromDomain(user));
    }
}

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Username
)
{
    public User ToDomain()
    {
        return new User
        {
            Email = Email,
            Usernmae = Username,
            FirstName = FirstName,
            LastName = LastName,
        };
    }
}



public record UserResponse(
    string Username,
    string FullName
)
{
    public static UserResponse FromDomain(User user) => new(user.Usernmae, FullName: string.Format("{0} {1}", user.FirstName, user.LastName));
    public static IEnumerable<UserResponse> FromDomain(IEnumerable<User> users) => users.Select(user => new UserResponse(user.Usernmae, FullName: string.Format("{0} {1}", user.FirstName, user.LastName)));

}

public record PagedUserResponse(
    int TotalCount,
    int TotalPages,
    int CurrentPage,
    int PageSize,
    IEnumerable<UserResponse> Users
);


public record QueryObjects(int Page = 1, int PageSize = 10);

