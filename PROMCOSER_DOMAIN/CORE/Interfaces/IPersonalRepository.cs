using PROMCOSER_DOMAIN.CORE.Entities;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IPersonalRepository
    {
        Task<Personal> SignIn(string username, string pwd);
        Task<bool> SignUp(Personal personal);
        Task<IEnumerable<Personal>> GetOperadores();
        Task<IEnumerable<Personal>> GetPersonal();
        Task<Personal> GetPersonalById(int id);
        Task<int> Insert(Personal personal);
        Task<bool> Update(Personal personal);
        Task<bool> Delete(int id);
    }
}