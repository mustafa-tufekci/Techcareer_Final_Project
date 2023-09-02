using EventHub.Core.Utilities.JWT;
using EventHub.Core.Utilities.Results;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;

namespace EventHub.BL.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string mail);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
