using EventHub.BL.Abstract;
using EventHub.Core.Utilities.Results;
using EventHub.DAL.Abstract;
using EventHub.Entities.Models;

namespace EventHub.BL.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal cityDal;

        public CityManager(ICityDal cityDal)
        {
            this.cityDal = cityDal;
        }

        public IResult Add(City city)
        {
            cityDal.Add(city);
            return new SuccessResult();
        }

        public IResult Delete(City city)
        {
            cityDal.Delete(city);
            return new SuccessResult();
        }

        public IDataResult<City> Get(int cityId)
        {
            return new SuccessDataResult<City>(cityDal.Get(x => x.CityID == cityId));
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(cityDal.GetAll());
        }

        public IResult Update(City city)
        {
            cityDal.Update(city);
            return new SuccessResult();
        }
    }
}
