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
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UsersController : Controller
    {
        private readonly GamificationDbContext _db;
        private readonly WalletService _wallet;  

        public UsersController(GamificationDbContext db, WalletService walletService)
        {
            _db = db;
            _wallet = walletService;
        }

        /// <summary>
        /// Метод получения объекта пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Объект пользователя</returns>
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

        /// <summary>
        /// Метод получения всех пользователей
        /// </summary>
        /// <returns>Все пользователи системы</returns>
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

        /// <summary>
        /// Метод получения баланса пользователя по его токену
        /// </summary>
        /// <param name="token">Токен авторизованного пользователя</param>
        /// <returns>Баланс кошелька пользователя</returns>
        /// <exception cref="Exception"></exception>
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
                ruble = wallet.CoinsAmount
            });
        }

        /// <summary>
        /// Метод получения истории транзакций
        /// </summary>
        /// <param name="token">Токен авторизованного пользователя</param>
        /// <returns>История транзакций</returns>
        /// <exception cref="Exception"></exception>
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


        /// <summary>
        /// Метод получения пользователя по его публичному ключу
        /// </summary>
        /// <param name="publicKey">Публичный ключ пользователя</param>
        /// <returns>Объект пользователя</returns>
        public string Deanonimize(string publicKey)
        {
            User user = _db.Users.Where(x => x.PublicKey.ToLower() == publicKey.ToLower()).FirstOrDefault();
            if (user != null )
            {
                return user.Name;
            }

            return null;
        }

        /// <summary>
        /// Метод перевода валюты другому пользователю
        /// </summary>
        /// <param name="token">Токен авторизированного пользователя.</param>
        /// <param name="UserTo">Идентификатор конечного пользователя</param>
        /// <param name="count">Количество монет для перевода</param>
        /// <returns>Объект транзакции</returns>
        /// <exception cref="Exception"></exception>
        public IActionResult Transfer(string token, int UserTo, double count)
        {
            User userFrom = _db.Users.Where(x => x.Token == token).FirstOrDefault();

            if (userFrom == null)
                throw new Exception("Некорректный токен авторизации!");

            if (string.IsNullOrWhiteSpace(userFrom.PrivateKey))
            {
                throw new Exception("Кошелек отправителя не найден!");
            }

            User userTo = _db.Users.Where(x => x.Id == UserTo).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(userFrom.PublicKey))
            {
                throw new Exception("Кошелек отправителя не найден!");
            }

            var transaction = _wallet.SentTokens(userFrom.PrivateKey, userTo.PublicKey, count);


            return Json(transaction);
        }

        /// <summary>
        /// Метод для удаления монет с кошелька пользователя
        /// </summary>
        /// <param name="token">Токен авторизованного пользователя</param>
        /// <param name="count">Количество монет для удаления</param>
        /// <returns>Объект транзакции</returns>
        /// <exception cref="Exception"></exception>
        public IActionResult RemoveTokens(string token, double count)
        {
            User userFrom = _db.Users.Where(x => x.Token == token).FirstOrDefault();

            if (userFrom == null)
                throw new Exception("Некорректный токен авторизации!");

            if (string.IsNullOrWhiteSpace(userFrom.PrivateKey))
            {
                throw new Exception("Кошелек отправителя не найден!");
            }
            
            var transaction = _wallet.SentTokens(userFrom.PrivateKey, "0xEFD60fC339921FD27E1056a5c245aE260e3096E5", count);
            return Json(transaction);
        }



    }
}
