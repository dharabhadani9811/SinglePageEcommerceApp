using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DharaProject.Models
{
    public class OrderModel
    {
        public Guid OrderModelID { get; set; }

        public Guid UserID { get; set; }
        public virtual UserModel User { get; set; } = default!;
        public ProductCategoryModel Products { get; set; } = default!;

        public int ProductQty { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderModel()
        {
            OrderModelID = Guid.NewGuid();
        }

        

       
    }
}
