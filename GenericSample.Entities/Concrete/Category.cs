using GenericSample.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
