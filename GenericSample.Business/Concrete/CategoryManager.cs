using GenericSample.Business.Abstract;
using GenericSample.DataAccess.Abstract;
using GenericSample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        public void Create(Category entity)
        {
            _categoryDAL.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDAL.Delete(entity);
        }

        public Category GetById(int? id)
        {
            return _categoryDAL.Get(i => i.Id == id);
        }

        public List<Category> GetAll()
        {
            return _categoryDAL.GetAll().ToList();
        }

        public List<Category> GetAllCategoriesInclude()
        {
            return _categoryDAL.GetAllCategoriesInclude();
        }

        public void Update(Category entity)
        {
            _categoryDAL.Update(entity);
        }
    }
}
