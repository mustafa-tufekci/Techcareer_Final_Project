using EventHub.BL.Abstract;
using EventHub.Core.Utilities.Results;
using EventHub.DAL.Abstract;
using EventHub.Entities.Models;

namespace EventHub.BL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<Category> Get(int categoryId)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(x => x.CategoryID == categoryId));
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll());
        }

        public IResult Update(Category category)
        {
            categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
