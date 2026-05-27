using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.User;
namespace HomeEstate.BusinessLogic.Interface
{
    public interface IAuthService
    {
        ResponseMessage Register(UserRegisterDto data);
        UserSessionDto Login(UserLoginDto data);
        ResponseMessage Logout(string token);
        UserSessionDto GetSession(string token);
        List<UserListDto> GetAllUsers();
    }
}
