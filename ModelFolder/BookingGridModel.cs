using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.ModelFolder
{
    public class BookingGridModel
    {
        public string Size { get; set; } // "S", "M", "L"
        public int Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
