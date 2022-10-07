using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendUni.Controllers
{
    public class HomeController : Controller
    {
        private readonly GamificationDbContext _db;



        public HomeController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            _db.Users.Add(new User() 
            { 
                Name = "Andrey",
                Login = "andrey",
                Password = "110011"
            });

            _db.SaveChanges();

            return Json(_db.Users.ToArray());
        }
    }
}