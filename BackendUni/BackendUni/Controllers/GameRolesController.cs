using Backend.DAL.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace BackendUni.Controllers
{
    public class GameRolesController : Controller
    {
        private readonly GamificationDbContext _db;
        Random _random = new Random();

        public GameRolesController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult GetUserGameRoles(int userId, string token)
        {
            return Json(new NotImplementedException());
        }
    }
}
