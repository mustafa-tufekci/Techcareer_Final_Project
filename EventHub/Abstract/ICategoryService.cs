using EventHub.Core.Utilities.Results;
using EventHub.Entities.Models;

namespace EventHub.BL.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> Get(int categoryId);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
