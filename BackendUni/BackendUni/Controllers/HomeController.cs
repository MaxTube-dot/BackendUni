using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendUni.Controllers
{
    public class HomeController : Controller
    {
        private readonly GamificationDbContext _db;



        public HomeController(GamificationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return Content("         \n"+
"         _    ____ ___    ___ ____   __        _____  ____  _  _____ _   _  ____      \n"+
"        / \\  |  _ \\_ _|  |_ _/ ___|  \\ \\      / / _ \\|  _ \\| |/ /_ _| \\ | |/ ___|     \n"+
"       / _ \\ | |_) | |    | |\\___ \\   \\ \\ /\\ / / | | | |_) |  / | ||  \\| | |  _      \n"+
"      / ___ \\|  __/| |    | | ___) |   \\ V  V /| |_| |  _ <| . \\ | || |\\  | |_| |     \n"+
"     /_/   \\_\\_|  |___|  |___|____/     \\_/\\_/  \\___/|_| \\_\\_|\\_\\___|_| \\_|\\____|     \n"+
"                                                                                     \n"+
"       ");
        }

        
    }
}