using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DharaProject.Models
{
    public class ProductCategoryModel 
    {

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public ProductModel Product { get; set; } = default!;
        public CategoryModel Category { get; set; } = default!;


    }
}
