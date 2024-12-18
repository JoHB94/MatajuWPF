using Mataju.ModelFolder;
using Mataju.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mataju.VMFolder
{
    public class DetailViewModel : ViewModelBase
    {
        private readonly int houseId;
        
        //HouseModel 변경감지
        private HouseModel _selectedHouse;
        public HouseModel SelectedHouse
        {
            get => _selectedHouse;
            set
            {
                if (_selectedHouse != value)
                {
                    _selectedHouse = value;
                    OnPropertyChanged(nameof(SelectedHouse)); // 변경 통지
                }
            }
        }


        public DetailViewModel(int houseId)
        {
            this.houseId = houseId;
            BookCommand = new RelayCommand(OnBookCommandExecuted);
        }

        private ObservableCollection<UnitModel> _units;
        public ObservableCollection<UnitModel> Units
        {
            get => _units;
            set
            {
                if (_units != value)
                {
                    _units = value;
                    OnPropertyChanged(nameof(Units));
                    OnPropertyChanged(nameof(GroupedUnits));
                }
            }
        }

        //DataGrid 읽기 전용
        private ObservableCollection<BookingGridModel> _groupedUnits;
        public ObservableCollection<BookingGridModel> GroupedUnits
        {
            get => _groupedUnits;
            set
            {
                if(_groupedUnits != value)
                {
                    _groupedUnits = value;
                    OnPropertyChanged(nameof(GroupedUnits));
                }
            }
        }

        private string[] _imagePaths;
        public string[] ImagePaths
        {
            get => _imagePaths;
            set
            {
                if (_imagePaths != value)
                {
                    _imagePaths = value;
                    OnPropertyChanged(nameof(ImagePaths));
                }
            }
        }

        //estimateTable
        private ObservableCollection<BookingGridModel> _estimateTables;
        private BookingGridModel _selectedEstimateTable;  // 현재 선택된 EstimateTable

        public ObservableCollection<BookingGridModel> EstimateTables
        {
            get => _estimateTables;
            set
            {
                _estimateTables = value;
                OnPropertyChanged(nameof(EstimateTables));
            }
        }

        public BookingGridModel SelectedEstimateTable
        {
            get => _selectedEstimateTable;
            set
            {
                _selectedEstimateTable = value;
                OnPropertyChanged(nameof(SelectedEstimateTable));
            }
        }

        public ICommand BookCommand { get; set; }
        
        // 예약 버튼 클릭 시 처리하는 메소드
        private async void OnBookCommandExecuted()
        {
            if (SelectedEstimateTable != null)
            {
                var booking = new BookingModel
                {
                    UserId = LoginViewModel.userId,  // -> 로그인 시 static 변수로 UserId 받아야 함
                    HouseId = this.houseId, // -> 생성자로 받아올 예정
                    UnitSize = SelectedEstimateTable.Size,
                    StartDate = SelectedEstimateTable.StartDate?.ToString("yyyy-MM-dd"),
                    DurationDays = (SelectedEstimateTable.EndDate - SelectedEstimateTable.StartDate)?.Days,
                    UserNote = ""
                };

                // API 호출을 위한 서비스 호출
                await DetailService.BookingUnit(booking);  // ApiService는 예약을 처리하는 서비스입니다.
            }
        }
    }
}
