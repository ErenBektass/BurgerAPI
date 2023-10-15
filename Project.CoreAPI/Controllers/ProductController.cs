using Microsoft.AspNetCore.Mvc;
using Project.CoreAPI.Models;
using Project.CoreAPI.Models.Request;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.CoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProductController : ControllerBase
    {
        MyContext _db;

        private readonly ILogger<WeatherForecastController> _logger;
        public ProductController(MyContext db)
        {
            _db = db;
        }
        [HttpGet("ListProduct")]
        public IEnumerable<ProductModel> ListProduct()
        {
            return _db.Products.Select(x => new ProductModel
            {
                Name = x.ProductName,
                UnitPrice = x.UnitPrice,
            }).ToList();
        }
        [HttpPost("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {

            Product product = _db.Products.FirstOrDefault(x => x.ID == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return Ok();
            }
            else
            {
                throw new Exception("Ürün bulunamadý");
            }

           
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(RequestAddProduct request)
        {
            Product product = new Product()
            {
               ProductName= request.ProductName,
               UnitPrice= request.UnitPrice,
               CategoryID= request.CategoryID,
               UnitsInStock= request.UnitsInStock,
            };
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok();
        }






        //[HttpGet(Name = "ListCategories")]
        //public IEnumerable<CategoryModel> Get()
        //{
        //    return _db.Categories.Select(x => new CategoryModel
        //    {
        //        Name = x.CategoryName,
        //        ID = x.ID,
        //        Description = x.Description
        //    }).ToList();
        //}





    }
}