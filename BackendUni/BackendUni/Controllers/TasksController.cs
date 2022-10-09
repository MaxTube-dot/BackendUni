using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Task = Backend.DAL.Models.Task;

namespace BackendUni.Controllers
{
    /// <summary>
    /// Контроллер ивентов.
    /// </summary>
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

        /// <summary>
        /// Метод, возвращающий ивенты указанного пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="token">Токен авторизованного пользователя</param>
        /// <returns>Перечень ивентов пользователя</returns>
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


        /// <summary>
        /// Метод получения всех ивентов
        /// </summary>
        /// <returns>Перечень всех ивентов</returns>
        public IActionResult GetAllTasks()
        {
            return Json(_db.Tasks.Include(x => x.Marks).Where(x => !x.IsAnnouncement).ToArray(), _options);
        }

        /// <summary>
        /// Метод получения всех мероприятий
        /// </summary>
        /// <returns>Перечень мероприятий</returns>
        public IActionResult GetAllAnnouncement()
        {
            return Json(_db.Tasks.Where(x => x.IsAnnouncement).ToArray(), _options);
        }


        /// <summary>
        /// Метод для принятия ивента в процесс.
        /// </summary>
        /// <param name="taskId">Идентификатор ивента.</param>
        /// <param name="token">Токен авторизованного пользователя</param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод создания нового ивента
        /// </summary>
        /// <param name="token">Токен авторизованного пользователя</param>
        /// <param name="name">Название ивента</param>
        /// <param name="dateTime">Дата проведения ивента</param>
        /// <param name="price">Баллы за выполнение</param>
        /// <param name="marks">Метки ивента</param>
        /// <param name="users">Целевые пользователи ивента</param>
        /// <returns>Объект созданного ивента</returns>
        public IActionResult CreateTask(string token, string name, DateTime? dateTime, int price, 
            [FromQuery(Name = "marks[]")] int[] marks, [FromQuery(Name = "users[]")] int[] users)
        {
            User user = _db.Users.FirstOrDefault(x => x.Token == token);

            if (user == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;

                return Json(null);
            }

            var task = new Task()
            {
                Id = _db.Tasks.OrderBy(x => x.Id).Last().Id + 1,
                Created = DateTime.Now,
                Name = name,
                Creator = user,
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Marks = _db.Marks.Where(x => marks.Contains(x.Id)).ToList(),
                Price = price,
                TargetUsers = _db.Users.Where(x => users.Contains(x.Id)).ToList()
            };

            _db.Tasks.Add(task);

            _db.SaveChanges();

            return Json(task, _options);
        }
    }
}
