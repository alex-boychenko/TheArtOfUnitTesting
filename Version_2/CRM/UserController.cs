namespace TheArtOfUnitTesting;

public class UserController
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public void ChangeEmail(int userId, string newEmail)
    {
        _userService.ChangeEmail(userId, newEmail);
    }
}

