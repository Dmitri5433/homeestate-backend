using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.User;

namespace HomeEstate.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        ResponceMsg RegisterAction(UserRegisterDto data);
        UserSessionDto? LoginAction(UserLoginDto data);
        ResponceMsg LogoutAction(string token);
        UserSessionDto? GetSessionAction(string token);
    }
}
