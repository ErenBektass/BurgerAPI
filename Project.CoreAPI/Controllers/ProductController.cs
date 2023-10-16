using Microsoft.AspNetCore.Mvc;
using Project.CoreAPI.Models;
using Project.CoreAPI.Models.Request;
using Project.CoreAPI.Services;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.CoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    
    public class ProductController : ControllerBase
    {
        MyContext _db;
        ProductService _ps;

        private readonly ILogger<WeatherForecastController> _logger;
        public ProductController(MyContext db)
        {
            _db = db;
            _ps = new ProductService(db);
        }
        [HttpGet("ListProduct")]
        public IEnumerable<ProductModel> ListProduct()
        {
            return _ps.GetProductList();
        }
        [HttpPost("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _db.Products.Find(id);
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
               UnitsInStock= request.UnitInStock,
            };
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct(RequestUpdateProduct request)
        {
            Product product = _db.Products.Find(request.ProductID);
            if (product != null)
            {
                product.ProductName = request.ProductName;
                product.UnitPrice = request.UnitPrice;
                product.UnitsInStock =Convert.ToInt16(request.UnitInStock);
                product.ModifiedDate = DateTime.Now;
                _db.Products.Update(product);
                _db.SaveChanges();
            }


            /*Product product = new Product()
            {
                 ID=request.ProductID,
                 ProductName=request.ProductName,
                 UnitPrice=request.UnitPrice,
                 UnitsInStock=request.UnitInStok
            };
            _db.Products.Update(product);
            _db.SaveChanges();*/
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