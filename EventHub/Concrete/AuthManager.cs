using EventHub.BL.Abstract;
using EventHub.Core.Utilities.JWT;
using EventHub.Core.Utilities.Results;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventHub.BL.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService userService;
        readonly IConfiguration configuration;
        TokenOption tokenOption;

        public AuthManager(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
            tokenOption = this.configuration.GetSection("TokenOption").Get<TokenOption>();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));

            var userRole = userService.GetClaim(user);
            if (userRole == null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }
            claims.Add(new Claim(ClaimTypes.Role, userRole));

            var dateTimeNow = DateTime.Now.AddDays(tokenOption.Expiration);

            JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer: tokenOption.Issuer,
                    audience: tokenOption.Audience,
                    claims: claims,
                    expires: dateTimeNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(tokenOption.SecretKey)), SecurityAlgorithms.HmacSha256)
                    );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string userToken = tokenHandler.WriteToken(securityToken);

            AccessToken token = new AccessToken()
            {
                Token = userToken,
                Expiration = dateTimeNow
            };

            return new SuccessDataResult<AccessToken>(token);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userCheck = userService.GetByMail(userForLoginDto.Email);
            if (userCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı Bulunamadı");
            }

            if (userCheck.Password != userForLoginDto.Password)
            {
                return new ErrorDataResult<User>("Parola veya kullanıcı adı hatalı");
            }

            return new SuccessDataResult<User>(userCheck, "Başarılı giriş");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Password = userForRegisterDto.Password,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
            };
            userService.Add(user);
            return new SuccessDataResult<User>(user, "Successfully Registered");
        }

        public IResult UserExists(string mail)
        {
            if (userService.GetByMail(mail) != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
