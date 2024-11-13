using PROMCOSER_DOMAIN.CORE.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;
using static PROMCOSER_DOMAIN.CORE.DTO.PersonalDTO;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IPersonalService
    {
        Task<Personal> SignIn(string username, string password);
        Task<bool> SignUp(UserRequestAuthDTO userDTO);
    }
}