using GenericSample.Business.Abstract;
using GenericSample.DataAccess.Abstract;
using GenericSample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public void Create(Product entity)
        {
            _productDAL.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDAL.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll().ToList();
        }
        
        public List<Product> GetAllProductsInclude()
        {
            return _productDAL.GetAllProductsInclude();
        }

        public Product GetById(int? id)
        {
            return _productDAL.Get(i => i.Id == id);
        }

        public List<Product> GetProductsByCategory(int? id)
        {
            return _productDAL.GetProductsByCategory(id);
        }

        public void Update(Product entity)
        {
            _productDAL.Update(entity);
        }
    }
}
