

using OrderCustomerApi.Data.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCustomerApi.Entities
{
    public  class Order: IRecoverableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CustomerGuid { get; set; }
        public decimal Amount { get; set; }
        public Guid AddressGuid { get; set; }

    }
}