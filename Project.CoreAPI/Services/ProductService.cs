using Project.CoreAPI.Models;
using Project.DAL.Context;

namespace Project.CoreAPI.Services
{
    public class ProductService
    {
        MyContext _db;

        public ProductService(MyContext db)
        {
                _db = db;
        }
        public IEnumerable<ProductModel> GetProductList()
        {
            return _db.Products.Select(x => new ProductModel
            {
                Name = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock
            }).ToList();
        }
    }
}
