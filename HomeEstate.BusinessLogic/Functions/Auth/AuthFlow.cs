using HomeEstate.BusinessLogic.Core.Auth;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.User;
namespace HomeEstate.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponceMsg Register(UserRegisterDto data) => ExecuteRegisterAction(data);
        public UserSessionDto? Login(UserLoginDto data) => ExecuteLoginAction(data);
        public ResponceMsg Logout(string token) => ExecuteLogoutAction(token);
        public UserSessionDto? GetSession(string token) => ExecuteGetSessionAction(token);
    }
}
