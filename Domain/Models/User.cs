namespace Domain.Models;

public class User(Guid id, string username, string password, string role)
{
    public Guid Id { get; set; } = id;
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
    public string Role { get; set; } = role;
}