namespace Project.CoreAPI.Models.Request
{
    public class RequestAddProduct
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public int UnitsInStock { get; set; }
    }
}
