using Microsoft.AspNetCore.Mvc;

namespace BackendUni.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
