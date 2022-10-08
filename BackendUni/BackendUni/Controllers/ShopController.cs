using Backend.DAL.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace BackendUni.Controllers
{
    public class ShopController : Controller
    {
        private readonly GamificationDbContext _db;

        public ShopController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult GetAllProducts()
        {
            return Json(_db.Products.ToArray());
        }
    }
}
