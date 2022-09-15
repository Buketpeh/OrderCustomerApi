using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Entities
{
    public class Country
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
