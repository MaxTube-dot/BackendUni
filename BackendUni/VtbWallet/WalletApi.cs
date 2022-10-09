using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VtbWallet.Helpers;
using VtbWallet.Models;
using VtbWallet.Models.Responses;

namespace VtbWallet
{
    /// <summary>
    /// Класс для интеграции в BlockChain
    /// </summary>
    public static class WalletApi
    {
        private static WalletHelper WalletHelper = new WalletHelper(); 
        public static Wallet CreateWallet()
        {
           var keys =  WalletHelper.CreateWallet();
            return new Wallet() { PrivateKey = keys.PrivateKey, PublicKey = keys.PublicKey };
        }


        /// <summary>
        /// Получение баланса
        /// </summary>
        /// <param name="publicKey">Публичный токен</param>
        /// <returns>Кошелек </returns>
        public static Wallet GetBalance(string publicKey)
        {
            var result = WalletHelper.GetBalance(publicKey);
            return new Wallet() { MaticAmount = result.MaticAmount, CoinsAmount = result.CoinsAmount };
        }

        public static Wallet GetBalance(Wallet wallet)
        {
            var result = WalletHelper.GetBalance(wallet.PublicKey);
            wallet.MaticAmount = result.MaticAmount;
            wallet.CoinsAmount = result.CoinsAmount;
            return wallet;
        }



        /// <summary>
        /// Метод для перевода цифровой валюты Ruble, с кошелька на кошелек.
        /// </summary>
        /// <param name="fromPrivateKey">Приватный ключ кошелька отправителя </param>
        /// <param name="toPublicKey">Публичный ключ получателя</param>
        /// <param name="amount">Колличесво монет.</param>
        /// <returns>Код транзакции</returns>
        public static TransactionCustom TransfersRuble(string fromPrivateKey, string toPublicKey,double amount)
        {
            var result = WalletHelper.TransfersRuble(fromPrivateKey, toPublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash};
        }

        public static TransactionCustom TransfersRuble(Wallet walletFrom, Wallet walletTo, double amount)
        {
            var result = WalletHelper.TransfersRuble(walletFrom.PrivateKey, walletTo.PublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash };
        }




        /// <summary>
        /// Метод для перевода цифровой валюты Matic, с кошелька на кошелек.
        /// </summary>
        /// <param name="fromPrivateKey">Приватный ключ кошелька отправителя </param>
        /// <param name="toPublicKey">Публичный ключ получателя</param>
        /// <param name="amount">Колличесво монет.</param>
        /// <returns>Код транзакции.</returns>
        public static TransactionCustom TransfersMatic(string fromPrivateKey, string toPublicKey, double amount)
        {
            var result = WalletHelper.TransfersMatic(fromPrivateKey, toPublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash };
        }

        public static TransactionCustom TransfersMatic(Wallet walletFrom, Wallet walletTo, double amount)
        {
            var result = WalletHelper.TransfersRuble(walletFrom.PrivateKey, walletTo.PublicKey, amount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash };
        }



        /// <summary>
        /// Получение истории транзакций по кошельку 
        /// </summary>
        /// <param name="publicKey">Публичный ключ</param>
        /// <param name="page">Кол-во страниц</param>
        /// <param name="offset">Кол-во транзакций на странице</param>
        /// <param name="sort">Метод сортировки</param>
        /// <returns>Исторический список транакций</returns>
        public static List<History> GetHistory(string publicKey, int page = 0, int offset = 0, string sort = "asc")
        {
            var result = WalletHelper.GetHistory(publicKey, page, offset, sort).Histories;
            return result;
        }

        public static Wallet GetHistory(Wallet wallet, int page = 0, int offset = 0, string sort = "asc")
        {
            var result = WalletHelper.GetHistory(wallet.PublicKey, page, offset, sort).Histories;
            wallet.Histories = result;
            return wallet;
        }



        /// <summary>
        /// Создание NFT
        /// </summary>
        /// <param name="publicKey">Публичный ключ владельца</param>
        /// <param name="uri">Ссылка на объект</param>
        /// <param name="nftCount">Кол-во объектов</param>
        /// <returns>Код транзакции</returns>
        public static TransactionCustom GenerateNFT(string publicKey, string uri, int nftCount)
        {
            var result = WalletHelper.GenerateNFT(publicKey, uri, nftCount);
            return new TransactionCustom() { TransactionHash = result.TransactionHash};
        }

        public static Wallet GenerateNFT(Wallet wallet, string uri, int nftCount)
        {
            var result = WalletHelper.GenerateNFT(wallet.PublicKey, uri, nftCount);
            return wallet;
        }




        /// <summary>
        /// Получение баланса NFT объекта
        /// </summary>
        /// <param name="publicKey">Публичный ключ кошелька</param>
        /// <returns>Список NFT</returns>
        public static List<NFT> GetNftBalance(string publicKey)
        {
            var result = WalletHelper.GetNftBalance(publicKey);
            return result.Balance;
        }

        public static Wallet GetNftBalance(Wallet wallet)
        {
            var result = WalletHelper.GetNftBalance(wallet.PublicKey);
            wallet.NFTs = result.Balance;
            return wallet;
        }


        /// <summary>
        /// Получение информации о объекте NFT
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public static NftInfo GetNftInfo(int tokenId)
        {
            var result = WalletHelper.GetNftInfo(tokenId);
            return result;
        }

    }
}
