using EventHub.Core.Utilities.Results;
using EventHub.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BL.Abstract
{
    public interface IUserRoleService
    {
        IResult Add(UserRole userRole);
        IResult Update(UserRole userRole);
        IResult Delete(UserRole userRole);
    }
}
