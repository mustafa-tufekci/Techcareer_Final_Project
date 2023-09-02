using EventHub.Core.DataAccess;
using EventHub.Entities.Models;

namespace EventHub.DAL.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        string GetClaim(User user);
    }
}
