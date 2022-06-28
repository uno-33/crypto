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
        private ApiHelper _apiHelper;

        public CurrencyEndpoint()
        {
            _apiHelper = new ApiHelper();
        }

        public async Task<List<CurrencyModel>> GetCurrencies(int limit, int offset)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"assets?offset={offset}&limit={limit}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<RootCurrenciesObject>();

                    //var result = JsonConvert.DeserializeObject<RootCurrenciesObject>(strResult);

                    return result.data;

                    //return new List<CurrencyModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
