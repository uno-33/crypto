using System;
using System.Collections.Generic;
using System.Text;

namespace crypto.Library.Models
{
    //"id": "bitcoin",
    //  "rank": "1",
    //  "symbol": "BTC",
    //  "name": "Bitcoin",
    //  "supply": "17193925.0000000000000000",
    //  "maxSupply": "21000000.0000000000000000",
    //  "marketCapUsd": "119150835874.4699281625807300",
    //  "volumeUsd24Hr": "2927959461.1750323310959460",
    //  "priceUsd": "6929.8217756835584756",
    //  "changePercent24Hr": "-0.8101417214350335",
    //  "vwap24Hr": "7175.0663247679233209"
    public class CurrencyModel
    {
        public string id { get; set; }
        public int rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public decimal supply { get; set; }
        public decimal? maxSupply { get; set; }
        public decimal marketCapUsd { get; set; }
        public decimal volumeUsd24Hr { get; set; }
        public decimal priceUsd { get; set; }
        public float? changePercent24Hr { get; set; }
        public decimal? vwap24Hr { get; set; }
    }
}
