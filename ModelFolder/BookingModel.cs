using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.ModelFolder
{
    internal class BookingModel
    {
        [JsonProperty("userId")]
        public int UserId {  get; set; }

        [JsonProperty("houseId")]
        public int HouseId { get; set; }

        [JsonProperty("unitSize")]
        public string UnitSize { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("durationDays")]
        public string DurationDays { get; set; }

        [JsonProperty("userNote")]
        public string UserNote { get; set; }
    }
}
