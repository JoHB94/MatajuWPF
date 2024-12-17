using Mataju.ModelFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mataju.VMFolder
{
    public class DetailViewModel : ViewModelBase
    {
        private HouseModel _selectedHouse;


        public HouseModel SelectedHouse
        {
            get => _selectedHouse;
            set
            {
                _selectedHouse = value;
                OnPropertyChanged(nameof(SelectedHouse));
            }
        }

        private string[] _imagePaths;
        // ImagePaths 속성 추가
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

        public DetailViewModel(HouseModel houseModel)
        {
            SelectedHouse = houseModel;
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



    }
}
