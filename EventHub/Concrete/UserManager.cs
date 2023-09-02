using EventHub.BL.Abstract;
using EventHub.Core.Utilities.Results;
using EventHub.DAL.Abstract;
using EventHub.Entities.Models;

namespace EventHub.BL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public IResult Add(User user)
        {
            userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            userDal.Update(user);
            return new SuccessResult("Parola başarıyla değiştirildi");
        }

        public IResult Delete(User user)
        {
            userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(userDal.Get(x => x.UserID == id));
        }

        public User GetByMail(string email)
        {
            return userDal.Get(x => x.Email == email);
        }

        public string GetClaim(User user)
        {
            return userDal.GetClaim(user);
        }
    }
}
