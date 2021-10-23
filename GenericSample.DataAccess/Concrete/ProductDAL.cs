using GenericSample.Core.DataAccess.EntityFramework;
using GenericSample.DataAccess.Abstract;
using GenericSample.DataAccess.Concrete.EntityFramework.Context;
using GenericSample.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.DataAccess.Concrete
{
    public class ProductDAL : EntityRepositoryBase<Product, ApplicationDbContext>, IProductDAL
    {
        public List<Product> GetAllProductsInclude()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Product>().Include(i => i.Category).OrderByDescending(i => i.Stock).ToList();
            }
        }

        public List<Product> GetProductsByCategory(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Product>().Include(i => i.Category).Where(i => i.CategoryId == id).OrderByDescending(i => i.Stock).ToList();
            }
        }
    }
}
