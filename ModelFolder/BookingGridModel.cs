using Mataju.VMFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.ModelFolder
{
    public class BookingGridModel : ViewModelBase
    {
        public string Size { get; set; } // "S", "M", "L"
        public int Price { get; set; }
        public int AvailableCount { get; set; }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TotalCost)); // StartDate 변경 시 TotalCost 업데이트
            }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(TotalCost)); // EndDate 변경 시 TotalCost 업데이트
            }
        }

        // TotalCost 읽기 전용 속성
        public decimal TotalCost
        {
            get
            {
                if (StartDate == null || EndDate == null)
                    return 0;

                var totalDays = (EndDate.Value - StartDate.Value).TotalDays;
                if (totalDays <= 30)
                    return Price; // 기본 요금 (30일 이하)
                else
                {
                    var extraDays = totalDays - 30;
                    return Price + (Price / 30 * (decimal)extraDays); // 기본 요금 + 초과 요금
                }
            }
        }
    }
}
