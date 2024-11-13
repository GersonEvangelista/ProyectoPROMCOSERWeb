using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Settings;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(Personal user);
    }
}