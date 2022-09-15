using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Entities
{
    public class Address
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid CountryGuid { get; set; }
        public Guid DistrictGuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
