using GenericSample.Core.DataAccess;
using GenericSample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.DataAccess.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        List<Category> GetAllCategoriesInclude();
    }
}
