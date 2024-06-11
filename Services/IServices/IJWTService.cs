using Domain.Identity;

namespace Services.IServices
{
    public interface IJWTService
    {
        string GenerateToken(ApplicationUser user);
    }
}
