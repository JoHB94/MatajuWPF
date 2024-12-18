using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.VMFolder
{
    public class EstimateTableViewModel : ViewModelBase
    {
        private string _size;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private decimal _price;
        private decimal _totalCost;

        public string Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                CalculateTotalCost();
            }
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                CalculateTotalCost();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public decimal TotalCost
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        public void CalculateTotalCost()
        {
            if (_startDate.HasValue && _endDate.HasValue)
            {
                // 기본 30일 기준 가격 계산
                decimal dailyRate = _price / 30;
                var totalDays = (_endDate.Value - _startDate.Value).Days;
                var totalCost = dailyRate * totalDays;

                // 총 비용을 10의 자리에서 반올림하여 계산
                TotalCost = Math.Ceiling(totalCost / 10) * 10;
            }
        }
    }
}
