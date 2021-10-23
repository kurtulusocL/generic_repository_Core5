using GenericSample.Business.Abstract.BaseService;
using GenericSample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.Business.Abstract
{
    public interface ICategoryService : IEntityBusinessService<Category>
    {
        List<Category> GetAllCategoriesInclude();
    }
}
