using EventHub.Core.DataAccess.EntityFramework;
using EventHub.DAL.Abstract;
using EventHub.Entities.Models;

namespace EventHub.DAL.Concrete.EntityFramework
{
    public class UserDal : EfEntityRepositoryBase<User, EventHubDbContext>, IUserDal
    {
        public string GetClaim(User user)
        {
            using (var context = new EventHubDbContext())
            {
                var result = (from users in context.Users
                             join userroles in context.UserRoles
                                on users.UserID equals userroles.UserID
                             join roles in context.Roles
                                 on userroles.RoleID equals roles.RoleID
                             where userroles.UserID == user.UserID
                             select roles.RoleName).SingleOrDefault();

                return result ?? string.Empty;
            }
        }
    }
}
