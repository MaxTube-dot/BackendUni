using Backend.DAL.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendUni.Controllers
{
    /// <summary>
    /// Контроллер авторизации
    /// </summary>
    public class AuthController : Controller
    {
        private readonly GamificationDbContext _db;

        public AuthController(GamificationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Токен авторизации</returns>
        public IActionResult Login(string login, string password)
        {
            var user = _db.Users.Include(x => x.Role).FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;

                return Json(user);
            }
            else
            {
                string guid = Guid.NewGuid().ToString();

                user.Token = guid;
                _db.SaveChanges();

                return Json(new
                {
                    Guid = guid,
                    User = user
                });
            }
        }
    }
}
