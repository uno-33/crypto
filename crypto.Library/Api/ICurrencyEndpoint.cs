﻿using crypto.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crypto.Library.Api
{
    public interface ICurrencyEndpoint
    {
        Task<List<CurrencyModel>> GetCurrencies(int limit, int offset);
    }
}