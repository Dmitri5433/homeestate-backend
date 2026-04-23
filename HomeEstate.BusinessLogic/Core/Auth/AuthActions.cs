using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.User;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.User;

namespace HomeEstate.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        protected ResponceMsg ExecuteRegisterAction(UserRegisterDto data)
        {
            using (var db = new UserContext())
            {
                var existing = db.Users.FirstOrDefault(u => u.Email == data.Email);
                if (existing != null)
                    return new ResponceMsg { IsSuccess = false, Message = "Email already registered." };
                var user = new UserData
                {
                    UserName = data.UserName,
                    Email = data.Email,
                    Password = HashPassword(data.Password),
                    CreatedAt = DateTime.UtcNow
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "Registration successful." };
        }

        protected UserSessionDto? ExecuteLoginAction(UserLoginDto data)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == HashPassword(data.Password));
                if (user == null) return null;
                user.SessionToken = GenerateToken();
                db.SaveChanges();
                return new UserSessionDto { Id = user.Id, UserName = user.UserName, Email = user.Email, SessionToken = user.SessionToken };
            }
        }

        protected ResponceMsg ExecuteLogoutAction(string token)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.SessionToken == token);
                if (user == null) return new ResponceMsg { IsSuccess = false, Message = "Session not found." };
                user.SessionToken = null;
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "Logged out successfully." };
        }

        protected UserSessionDto? ExecuteGetSessionAction(string token)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.SessionToken == token);
                if (user == null) return null;
                return new UserSessionDto { Id = user.Id, UserName = user.UserName, Email = user.Email, SessionToken = user.SessionToken };
            }
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
