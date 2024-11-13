using PROMCOSER_DOMAIN.CORE.Entities;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IPersonalRepository
    {
        Task<Personal> SignIn(string username, string pwd);
        Task<bool> SignUp(Personal personal);
    }
}