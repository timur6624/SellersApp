namespace AuthService.Dtos;

public class LoginDto
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}