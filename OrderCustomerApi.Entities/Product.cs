using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Entities
{
    public class Product
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
