using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Task = Backend.DAL.Models.Task;

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
            User user = _db.Users.Include(x => x.Tasks)
                .ThenInclude(x => x.Marks)
                .FirstOrDefault(x => x.Id == userId);

            if (user == null || user.Token != token)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;

                return Json(null);
            }
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
                    Price = x.Price,
                    IsLiked = _db.Likes.Any(like => like.Task.Id == x.Id && like.User == user)
                }), _options);
            }
        }

        public IActionResult GetAllTasks()
        {
            return Json(_db.Tasks.Include(x => x.Marks).Where(x => !x.IsAnnouncement).ToArray(), _options);
        }

        public IActionResult GetAllAnnouncement()
        {
            return Json(_db.Tasks.Where(x => x.IsAnnouncement).ToArray(), _options);
        }



        public IActionResult Like(int taskId, string token)
        {
            User user = _db.Users.Include(x => x.Tasks).FirstOrDefault(x => x.Token == token);
            Task task = _db.Tasks.FirstOrDefault(x => x.Id == taskId);

            if (user == null || task == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;

                return Json(null);
            }
            else
            {
                _db.Likes.Add(new Like()
                {
                    Task = task,
                    User = user
                });

                _db.SaveChanges();

                return Json(new
                {
                    Id = task.Id,
                    Name = task.Name,
                    Created = task.Created,
                    ImageLink = task.ImageLink,
                    Marks = task.Marks,
                    Start = task.Start,
                    End = task.End,
                    Price = task.Price,
                    IsLiked = _db.Likes.Any(like => like.Task.Id == task.Id && like.User == user)
                });
            }

            
        }
    }
}
