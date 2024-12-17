using Mataju.VMFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.ModelFolder
{
    public class HouseModel : ViewModelBase
    {
        public override string ToString()
        {
            return $"Id: {HouseId}, add: {HouseAdd}, province: {Province}, priceS:{PriceS}, priceM:{PriceM}, priceL:{PriceL},"; // 출력하고 싶은 속성들을 추가하세요.
        }
        [JsonProperty("id")]
        public int HouseId { get; set; }

        [JsonProperty("add")]
        public string HouseAdd { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("priceS")]
        public int PriceS { get; set; }
        [JsonProperty("priceM")]
        public int PriceM { get; set; }
        [JsonProperty("priceL")]
        public int PriceL { get; set; }

    } 
       
}
