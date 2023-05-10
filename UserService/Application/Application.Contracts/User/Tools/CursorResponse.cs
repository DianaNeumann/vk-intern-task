namespace Application.Contracts.User.Tools;

public record CursorResponse<T>(long Cursor, T Data);