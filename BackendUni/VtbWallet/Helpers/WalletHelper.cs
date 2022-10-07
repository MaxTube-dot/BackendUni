using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using VtbWallet.Models.Requests;
using VtbWallet.Models.Responses;

namespace VtbWallet.Helpers
{
    public class WalletHelper
    {
        public readonly static string _baseUrl = "https://hackathon.lsp.team/hk";

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
                        new MediaTypeWithQualityHeaderValue("text/plain")
                    }
                }

            };
        }

        private Tout SendRequest<Tin, Tout>(Tin requestData, string actionType, HttpMethod httpMethod) where Tin : class where Tout : class
        {
            var request = new HttpRequestMessage(httpMethod, actionType)
            {
                Content = requestData != null ? new StringContent(JsonConvert.SerializeObject(requestData)) : null
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
            return SendRequest<CreateWalletRequest, CreateWalletResponse>(new CreateWalletRequest(), "/v1/wallets/new", HttpMethod.Post);
        }
    }
}
