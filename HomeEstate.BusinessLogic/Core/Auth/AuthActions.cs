using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.User;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.User;

namespace HomeEstate.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        protected readonly DbSession _db;

        public AuthActions(DbSession db)
        {
            _db = db;
        }

        protected ResponceMsg ExecuteRegisterAction(UserRegisterDto data)
        {
            var existing = _db.UserData.FirstOrDefault(u => u.Email == data.Email);
            if (existing != null)
                return new ResponceMsg { IsSuccess = false, Message = "Email already registered." };

            var user = new UserData
            {
                UserName = data.UserName,
                Email = data.Email,
                Password = HashPassword(data.Password),
                CreatedAt = DateTime.UtcNow
            };
            _db.UserData.Add(user);
            _db.SaveChanges();
            return new ResponceMsg { IsSuccess = true, Message = "Registration successful." };
        }

        protected UserSessionDto? ExecuteLoginAction(UserLoginDto data)
        {
            var user = _db.UserData.FirstOrDefault(u => u.Email == data.Email && u.Password == HashPassword(data.Password));
            if (user == null) return null;
            user.SessionToken = GenerateToken();
            _db.SaveChanges();
            return new UserSessionDto { Id = user.Id, UserName = user.UserName, Email = user.Email, SessionToken = user.SessionToken };
        }

        protected ResponceMsg ExecuteLogoutAction(string token)
        {
            var user = _db.UserData.FirstOrDefault(u => u.SessionToken == token);
            if (user == null) return new ResponceMsg { IsSuccess = false, Message = "Session not found." };
            user.SessionToken = null;
            _db.SaveChanges();
            return new ResponceMsg { IsSuccess = true, Message = "Logged out successfully." };
        }

        protected UserSessionDto? ExecuteGetSessionAction(string token)
        {
            var user = _db.UserData.FirstOrDefault(u => u.SessionToken == token);
            if (user == null) return null;
            return new UserSessionDto { Id = user.Id, UserName = user.UserName, Email = user.Email, SessionToken = user.SessionToken };
        }

        protected List<UserListDto> ExecuteGetAllUsersAction()
        {
            return _db.UserData.Select(u => new UserListDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                CreatedAt = u.CreatedAt
            }).ToList();
        }

        private string GenerateToken() => Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");

        private string HashPassword(string password)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            return Convert.ToHexString(sha.ComputeHash(bytes));
        }
    }
}