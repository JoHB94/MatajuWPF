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


        public DetailViewModel()
        {
            
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

    }
}
