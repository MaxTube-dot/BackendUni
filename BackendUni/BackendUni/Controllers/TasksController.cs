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

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public TasksController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult GetUserTasks(int userId, string token)
        {
            User user = _db.Users.Include(x => x.Tasks).FirstOrDefault(x => x.Id == userId);

            if (user == null || user.Token != token)
                return Json(null);
            else
            {
                return Json(user.Tasks.Where(x => !x.IsAnnouncement).ToArray().Select(x => new 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Created = x.Created,
                    ImageLink = x.ImageLink,
                    Marks = x.Marks,
                    Start = x.Start,
                    End = x.End,
                    Price = x.Price
                }), _options);
            }
        }

        public IActionResult GetAllTasks()
        {
            return Json(_db.Tasks.Where(x => !x.IsAnnouncement).ToArray(), _options);
        }

        public IActionResult GetAllAnnouncement()
        {
            return Json(_db.Tasks.Where(x => x.IsAnnouncement).ToArray(), _options);
        }

        public IActionResult Like(int taskId)
        {
            return null;
        }
    }
}
