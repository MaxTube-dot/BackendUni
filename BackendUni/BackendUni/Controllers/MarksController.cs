using Backend.DAL.DbContexts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackendUni.Controllers
{
    /// <summary>
    /// Контроллер меток ивентов.
    /// </summary>
    public class MarksController : Controller
    {
        private readonly GamificationDbContext _db;

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public MarksController(GamificationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Метод, возвращающий перечень всех существующих меток задач.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllMarks()
        {
            return Json(_db.Marks.ToArray());
        }
    }
}
