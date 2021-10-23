using GenericSample.Core.DataAccess.EntityFramework;
using GenericSample.DataAccess.Abstract;
using GenericSample.DataAccess.Concrete.EntityFramework.Context;
using GenericSample.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.DataAccess.Concrete
{
    public class CategoryDAL : EntityRepositoryBase<Category, ApplicationDbContext>, ICategoryDAL
    {
        public List<Category> GetAllCategoriesInclude()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Category>().Include(i => i.Products).OrderByDescending(i => i.Products.Count()).ToList();
            }
        }
    }
}