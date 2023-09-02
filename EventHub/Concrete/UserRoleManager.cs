using EventHub.BL.Abstract;
using EventHub.Core.Utilities.Results;
using EventHub.DAL.Abstract;
using EventHub.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BL.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal userRoleDal;
        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            this.userRoleDal = userRoleDal;
        }

        public IResult Add(UserRole userRole)
        {
            userRoleDal.Add(userRole);
            return new SuccessResult();
        }

        public IResult Delete(UserRole userRole)
        {
            userRoleDal.Delete(userRole);
            return new SuccessResult();
        }

        public IResult Update(UserRole userRole)
        {
            userRoleDal.Update(userRole);
            return new SuccessResult();
        }
    }
}
