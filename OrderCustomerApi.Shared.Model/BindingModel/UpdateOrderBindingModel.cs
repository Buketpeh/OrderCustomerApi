using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Shared.Model.BindingModel
{
    public class UpdateOrderBindingModel
    {
        public Guid Guid { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid AddressGuid { get; set; }
        public List<UpdateProductBindingModel> Products { get; set; }
    }
}
