using GenericSample.Core.DataAccess;
using GenericSample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.DataAccess.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>
    {
        List<Product> GetAllProductsInclude();
        List<Product> GetProductsByCategory(int? id);
    }
}
