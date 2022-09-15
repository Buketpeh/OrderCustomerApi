using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Entities
{
    public class District
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid CityGuid { get; set; }
    }
}
