using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using VtbWallet.Models.Requests;
using VtbWallet.Models.Responses;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mime;

namespace VtbWallet.Helpers
{
    public class WalletHelper
    {
        public readonly static string _baseUrl = "https://hackathon.lsp.team/hk/";

        private HttpClient CreateHttpClient()
        {
            return new HttpClient(new HttpClientHandler()
            {
                UseDefaultCredentials = true,
                UseProxy = false
            })
            {
                BaseAddress = new Uri(_baseUrl),
                DefaultRequestHeaders =
                {
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("application/json"),
                    }
                }

            };
        }

        private Tout SendRequest<Tin, Tout>(Tin requestData, string actionType, HttpMethod httpMethod) where Tin : class where Tout : class
        {
            var request = new HttpRequestMessage(httpMethod, actionType)
            {
                Content = requestData != null ? new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json") : null,
            };

            using (var client = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.Send(request);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Bad response from walletApi");

                    var responseString = response.Content.ReadAsStringAsync()?.Result;

                    if (string.IsNullOrWhiteSpace(responseString))
                    {
                        throw new Exception("Empty response from walletApi");
                    }

                    var res = JsonConvert.DeserializeObject<Tout>(responseString);
                    return res;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка при обращении к Wallet");
                }

            }
        }


        public CreateWalletResponse CreateWallet()
        {
            return SendRequest<CreateWalletRequest, CreateWalletResponse>(new CreateWalletRequest(), "v1/wallets/new", HttpMethod.Post);
        }

        public GetBalanceResponse GetBalance(string publicKey)
        {
            return SendRequest<GetBalanceRequest, GetBalanceResponse>(new GetBalanceRequest(), $"v1/wallets/{publicKey}/balance", HttpMethod.Get);
        }     
        
        public TransfersRubleResponse TransfersRuble(string fromPrivateKey, string toPublicKey,double amount)
        {
            return SendRequest<TransfersRubleRequest, TransfersRubleResponse>(new TransfersRubleRequest(fromPrivateKey, toPublicKey, amount), $"v1/transfers/ruble", HttpMethod.Post);
        }

        public TransfersMaticResponse TransfersMatic(string fromPrivateKey, string toPublicKey, double amount)
        {
            return SendRequest<TransfersMaticRequest, TransfersMaticResponse>(new TransfersMaticRequest(fromPrivateKey, toPublicKey, amount), $"v1/transfers/matic", HttpMethod.Post);
        }

        public GetHistoryResponse GetHistory(string publicKey, int page, int offset, string sort)
        {
            return SendRequest<GetHistoryRequest, GetHistoryResponse>(new GetHistoryRequest(page, offset, sort), $"v1/wallets/{publicKey}/history", HttpMethod.Post);
        }
    }
}
