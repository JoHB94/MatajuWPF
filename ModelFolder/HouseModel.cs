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
    internal class HouseModel : ViewModelBase
    {
        public override string ToString()
        {
            return $"Id: {HouseId}, 주소: {HouseAdd}, province: {Province}"; // 출력하고 싶은 속성들을 추가하세요.
        }

        [JsonProperty("id")]
        private int _houseId;
        public int HouseId { get => _houseId;
            set
            {
                if (_houseId != value)
                {
                    _houseId = value;
                    OnPropertyChanged(nameof(HouseId));
                }
            } 
        }

        [JsonProperty("add")]
        private string _houseAdd;
        public string HouseAdd
        {
            get => _houseAdd;
            set
            {
                if (_houseAdd != value)
                {
                    _houseAdd = value;
                    OnPropertyChanged(nameof(HouseAdd));
                }
            }
        }

        [JsonProperty("province")]
        private string _province;
        public string Province
        {
            get => _province;
            set
            {
                if (_province != value)
                {
                    _province = value;
                    OnPropertyChanged(nameof(Province));
                }
            }
        }

        [JsonProperty("priceS")]
        private int _priceS;
        public int PriceS
        {
            get => _priceS;
            set
            {
                if (_priceS != value)
                {
                    _priceS = value;
                    OnPropertyChanged(nameof(PriceS));
                }
            }
        }



        [JsonProperty("priceM")]
        private int _priceM;
        public int PriceM
        {
            get => _priceM;
            set
            {
                if (_priceM != value)
                {
                    _priceM = value;
                    OnPropertyChanged(nameof(PriceM));
                }
            }
        }

        [JsonProperty("priceL")]
        private int _priceL;
        public int PriceL
        {
            get => _priceL;
            set
            {
                if (_priceL != value)
                {
                    _priceL = value;
                    OnPropertyChanged(nameof(PriceL));
                }
            }
        }
    }
}
