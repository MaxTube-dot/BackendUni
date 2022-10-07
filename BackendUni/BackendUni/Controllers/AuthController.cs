using Backend.DAL.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace BackendUni.Controllers
{
    public class AuthController : Controller
    {
        private readonly GamificationDbContext _db;

        public AuthController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult Login(string login, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user == null)
                return Json(user);
            else
            {
                string guid = Guid.NewGuid().ToString();

                user.Token = guid;
                _db.SaveChanges();

                return Json(guid);
            }
        }
    }
}
