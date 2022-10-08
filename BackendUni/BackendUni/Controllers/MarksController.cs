using Backend.DAL.DbContexts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackendUni.Controllers
{
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

        public IActionResult GetAllMarks()
        {
            return Json(_db.Marks.ToArray());
        }
    }
}
