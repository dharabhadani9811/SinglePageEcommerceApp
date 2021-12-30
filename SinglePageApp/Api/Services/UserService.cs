using DharaProject.Configuration;
using DharaProject.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SinglePageApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SinglePageApp.Api.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(Guid id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserModel> _users = new List<UserModel>
    {
        new UserModel("Test","Subject","test123@test.com","test 123 fake address"),
    };

        private readonly JwtConfig _appSettings;

        public UserService(IOptions<JwtConfig> appSettings)
        {
             _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.FirstOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user != null)
            {
                var token = generateJwtToken(user);

                return new AuthenticateResponse(user, token);

            }
            return null;
            // authentication successful so generate jwt token
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _users;
        }

        public UserModel GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentNullException(nameof(id));
        }

        // helper methods

        private string generateJwtToken(UserModel user)
        {
            // generate token that is valid for  1 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secrets);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
    }
}
