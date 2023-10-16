namespace Project.CoreAPI.Models.Request
{
    public class RequestUpdateProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
}
