using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.Business.Abstract.BaseService
{
    public interface IEntityBusinessService<T>
    {
        List<T> GetAll();
        T GetById(int? id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
