using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.ModelFolder
{
    internal class HouseModel
    {

        [JsonProperty("id")]
        public int HouseId { get; }

        [JsonProperty("add")]
        public string HouseAdd { get; }

        [JsonProperty("province")]
        public string Province { get; }

        [JsonProperty("priceS")]
        public int PriceS { get; }

        [JsonProperty("priceM")]
        public int PriceM { get; }

        [JsonProperty("priceL")]
        public int PriceL { get; }
    }
}
