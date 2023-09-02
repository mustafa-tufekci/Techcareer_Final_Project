using EventHub.Core.Utilities.Results;
using EventHub.Entities.Models;

namespace EventHub.BL.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IDataResult<City> Get(int cityId);
        IResult Add(City city);
        IResult Update(City city);
        IResult Delete(City city);
    }
}
