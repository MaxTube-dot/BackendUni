using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendUni.Controllers
{
    public class UsersController : Controller
    {
        private readonly GamificationDbContext _db;

        public UsersController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult GetUser(int id)
        {
            User user = _db.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);

            if (user == null)
                return Json(user);
            else
            {
                return Json(new 
                { 
                    Id = user.Id, 
                    Name = user.Name,
                    Score = user.Score,
                    ImageLink = user.ImageLink,
                    Role = user.Role
                });
            }
        }

        public IActionResult GetAllUsers()
        {
            User[] users = _db.Users.Include(x => x.Role).ToArray();

            return Json(users.Select(user => new 
            {
                Id = user.Id,
                Name = user.Name,
                Score = user.Score,
                ImageLink = user.ImageLink,
                Role = user.Role
            }));
        }
    }
}
