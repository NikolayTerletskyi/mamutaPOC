namespace Mammuta.Infrastructure;

public interface IdentityHelper
{
    public bool ValidateToken(string token);

    public string GetUserIdFromToken(string token);
}
