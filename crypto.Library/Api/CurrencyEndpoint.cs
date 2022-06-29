using crypto.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace crypto.Library.Api
{
    public class CurrencyEndpoint : ICurrencyEndpoint
    {
        public async Task<List<CurrencyModel>> GetCurrencies(int limit, int offset)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"assets?offset={offset}&limit={limit}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<RootModel<CurrencyModel>>();

                    return result.data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<MarketModel>> GetMarketsByCurrencyId(string currencyId,int limit, int offset)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"assets/{currencyId}/markets?offset={offset}&limit={limit}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<RootModel<MarketModel>>();

                    return result.data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
