using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DharaProject.Models
{
    public class ProductModel 
    {
        public Guid UserId { get; protected set; }
        public Guid ProductModelId { get; protected set; }
        public string ProductName { get; set; }

        public double TotalPrice { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<CategoryModel> Category { get; set; } = default!;

        protected ProductModel():base()
        {
           
            ProductName = default!;
        }

       
    }
}
