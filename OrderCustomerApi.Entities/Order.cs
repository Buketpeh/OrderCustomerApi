namespace OrderCustomerApi.Entities
{
    public class Order
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ProductGuid { get; set; }
        public string Amount { get; set; }
        public string AddressGuid { get; set; }

    }
}