using Mataju.VMFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mataju.ModelFolder
{
    internal class CardModel : ViewModelBase
    {
        public int HouseId { get; set; }
        public string HouseAdd { get; set; }
        public string Province { get; set; }
        public string ImgPath { get; set; }

        //카드 클릭시 실행할 command
        public ICommand CardClickCommand { get; set; }

    }
}
