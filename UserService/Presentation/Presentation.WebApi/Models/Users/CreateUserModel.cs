namespace Presentation.WebApi.Models.Users;

public record CreateUserModel(string Login, string Password, int UserGroupId);