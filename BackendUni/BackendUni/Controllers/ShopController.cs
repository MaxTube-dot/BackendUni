using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using BackendUni.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendUni.Controllers
{
    public class ShopController : Controller
    {
        private readonly GamificationDbContext _db;
        private readonly WalletService _wallet;

        public ShopController(GamificationDbContext db, WalletService wallet)
        {
            _db = db;
            _wallet = wallet;
        }

        public IActionResult GetAllProducts()
        {
            return Json(_db.Products.ToArray());
        }

        public IActionResult Buy(string token, int productId)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == productId);

            var user = _db.Users.FirstOrDefault(x => x.Token == token);

            if(user == null || product == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;

                return Json(null);
            }

            _db.CartItems.Add(new CartItem()
            {
                Product = product,
                User = user,
                AddDate = DateTime.Now,
            });

            _db.SaveChanges();


            return Json(_wallet.RemoveTokens(user.PrivateKey, product.Price));
        }
    }
}
