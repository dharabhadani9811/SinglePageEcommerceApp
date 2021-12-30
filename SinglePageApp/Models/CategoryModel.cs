using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DharaProject.Models
{
    public class CategoryModel
    {   
        
        public Guid CategoryModelID { get; protected set; }

        public string CategoryName { get; protected set; } = default!;
        public ICollection<ProductModel> Product { get; set; } = default!;
    }
}
