namespace ShoesShoppingOnline.Models.DataModel
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalMoney { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customers { get; set; } = new CustomerModel();

    }
}
