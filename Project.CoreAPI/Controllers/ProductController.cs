using Microsoft.AspNetCore.Mvc;
using Project.CoreAPI.Models;
using Project.DAL.Context;

namespace Project.CoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        MyContext _db;
  

        private readonly ILogger<WeatherForecastController> _logger;

  
        public ProductController(MyContext db)
        {
            _db = db;
        }
        [HttpGet(Name = "ListProduct")]
        public IEnumerable<ProductModel> ListProduct()
        {
            return _db.Products.Select(x => new ProductModel 
            {
                Name = x.ProductName,
                UnitPrice = x.UnitPrice,
            }).ToList();
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