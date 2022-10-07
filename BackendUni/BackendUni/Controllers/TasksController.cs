using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackendUni.Controllers
{
    public class TasksController : Controller
    {
        private readonly GamificationDbContext _db;

        public TasksController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult GetUserTasks(int userId)
        {
            User user = _db.Users.Include(x => x.Tasks).FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return Json(user);
            else
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                return Json(user.Tasks.ToArray(), options);
            }
        }

        public IActionResult GetAllTasks()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            return Json(_db.Tasks.ToArray(), options);
        }

        public IActionResult Like(int taskId)
        {
            return null;
        }
    }
}
