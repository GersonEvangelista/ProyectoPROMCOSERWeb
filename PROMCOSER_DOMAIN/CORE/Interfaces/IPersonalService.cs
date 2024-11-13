using PROMCOSER_DOMAIN.CORE.DTO;
using static PROMCOSER_DOMAIN.CORE.DTO.PersonalDTO;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IPersonalService
    {
        Task<UserAuthDTO> SignIn(string username, string password);
        Task<bool> SignUp(UserRequestAuthDTO userDTO);
    }
}