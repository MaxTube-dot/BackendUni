using Backend.DAL.DbContexts;
using Backend.DAL.Models;
using BackendUni.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using VtbWallet.Models;

namespace BackendUni.Controllers
{
    public class UsersController : Controller
    {
        private readonly GamificationDbContext _db;
        private readonly WalletService _wallet;  

        public UsersController(GamificationDbContext db, WalletService walletService)
        {
            _db = db;
            _wallet = walletService;
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

        public IActionResult GetBalance(string token)
        {
            User user = _db.Users.Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
                throw new Exception("Некорректный токен авторизации!");

            if (string.IsNullOrWhiteSpace(user.PublicKey) || string.IsNullOrWhiteSpace(user.PrivateKey))
            {
                throw new Exception("Кошелек не создан или создан некорректно, обратитесь пожалуйста к администратору!");
            }

            Wallet wallet =  _wallet.GetBalance(user.PublicKey);

            return Json( new
            {
                ruble = wallet.CoinsAmount,
                matic = wallet.MaticAmount
            });
        }


        public IActionResult CreateWallet(string token)
        {
            User user = _db.Users.Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
                throw new Exception("Некорректный токен авторизации!");

            if (!string.IsNullOrWhiteSpace(user.PublicKey) || !string.IsNullOrWhiteSpace(user.PrivateKey))
            {
                throw new Exception("Кошелек уже создан!");
            }

            Wallet wallet = _wallet.CreateWallet();
            user.PrivateKey = wallet.PrivateKey;
            user.PublicKey = wallet.PublicKey;
            _db.SaveChanges();

            return Json("Ok");
        }

        public IActionResult GetHistory (string token)
        {
            User user = _db.Users.Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
                throw new Exception("Некорректный токен авторизации!");

            if (string.IsNullOrWhiteSpace(user.PublicKey) || string.IsNullOrWhiteSpace(user.PrivateKey))
            {
                throw new Exception("Кошелек не создан или создан некорректно, обратитесь пожалуйста к администратору!");
            }

            var history = _wallet.GetHistory(user.PublicKey)
                .Select(o =>
                new
                {
                    BlockNumber = o.BlockNumber,
                    TokenName = o.TokenName,
                    From = o.From,
                    FromName = Deanonimize(o.From),
                    To = o.To,
                    ToName = Deanonimize(o.To),
                    value = o.Value
                }).ToList();

            return Json(history);
        }

        public string Deanonimize(string publicKey)
        {
            User user = _db.Users.Where(x => x.PublicKey.ToLower() == publicKey.ToLower()).FirstOrDefault();
            if (user != null )
            {
                return user.Name;
            }

            return null;
        }



    }
}
