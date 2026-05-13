using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.User;
namespace HomeEstate.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        ResponceMsg Register(UserRegisterDto data);
        UserSessionDto? Login(UserLoginDto data);
        ResponceMsg Logout(string token);
        UserSessionDto? GetSession(string token);
    }
}
