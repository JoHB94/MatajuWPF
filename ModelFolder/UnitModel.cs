using Mataju.VMFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.ModelFolder
{
    public class UnitModel : ViewModelBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("houseId")]
        public int HouseId { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
