using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DharaProject.Models
{
    public class Cart 
    {
        public Guid CartID { get; protected set; }

        public Guid UserID { get; protected set; }
        public UserModel User { get; protected set; } = default!;

        public ProductCategoryModel Products { get; protected set; } = default!;
        
    }
}
