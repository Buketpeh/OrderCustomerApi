using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Shared.Model.BindingModel
{
    public class AddOrderBindingModel
    {
        public Guid CustomerGuid { get; set; }
        public Guid AddressGuid { get; set; }
        public List<ProductBindingModel> Products { get; set; }
    }
}
