using System;
using System.Collections.Generic;
using System.Text;

namespace crypto.Library.Models
{
    //"exchangeId": "Binance",
    //  "baseId": "bitcoin",
    //  "quoteId": "tether",
    //  "baseSymbol": "BTC",
    //  "quoteSymbol": "USDT",
    //  "volumeUsd24Hr": "277775213.1923032624064566",
    //  "priceUsd": "6263.8645034633024446",
    //  "volumePercent": "7.4239157877678087"
    public class MarketModel
    {
        public string exchangeId { get; set; }
        public string baseId { get; set; }
        public string quoteId { get; set; }
        public string baseSymbol { get; set; }
        public string quoteSymbol { get; set; }
        public double? volumeUsd24Hr { get; set; }
        public decimal priceUsd { get; set; }
        public decimal? volumePercent { get; set; }
    }
}
