using EventHub.Core.Utilities.Results;
using EventHub.Entities.Models;

namespace EventHub.BL.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        User GetByMail(string email);
        string GetClaim(User user);
    }
}
