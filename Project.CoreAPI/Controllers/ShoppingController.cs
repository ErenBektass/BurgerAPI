using Microsoft.AspNetCore.Mvc;
using Project.CoreAPI.Models;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.CoreAPI.Controllers
{
    public class ShoppingController : Controller
    {
        MyContext _db;
        public ShoppingController(MyContext db)
        {
           _db = db;
        }
        
        



    }
}
