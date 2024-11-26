using PROMCOSER_DOMAIN.CORE.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;
using static PROMCOSER_DOMAIN.CORE.DTO.PersonalDTO;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IPersonalService
    {
        Task<UserToken> SignIn(string username, string password);
        Task<bool> SignUp(UserRequestAuthDTO userDTO);
        Task<IEnumerable<Personal>> GetOperadores();
        Task<bool> Delete(int id);
        Task<IEnumerable<PersonalDTOfrontEnd>> GetPersonal();
        Task<IEnumerable<PersonalDTOfrontEnd2>> GetPersonalDialog();
        Task<PersonalDTOfrontEnd2> GetPersonalyById(int id);
        Task<int> Insert(PersonalDTOfrontEnd2 personalDTO);
        Task<bool> Update(PersonalDTOfrontEnd2 personalDTO);
        Task<bool> LogicalDelete(int id);

    }
}