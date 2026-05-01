using HomeEstate.BusinessLogic.Core.Auth;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.User;

namespace HomeEstate.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponceMsg RegisterAction(UserRegisterDto data) => ExecuteRegisterAction(data);
        public UserSessionDto? LoginAction(UserLoginDto data) => ExecuteLoginAction(data);
        public ResponceMsg LogoutAction(string token) => ExecuteLogoutAction(token);
        public UserSessionDto? GetSessionAction(string token) => ExecuteGetSessionAction(token);
        public List<HomeEstate.Domains.Models.User.UserListDto> GetAllUsersAction() => ExecuteGetAllUsersAction();
    }
}

