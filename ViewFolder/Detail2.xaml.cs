using Mataju.ModelFolder;
using Mataju.Service;
using Mataju.VMFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mataju.ViewFolder
{
    /// <summary>
    /// Detail2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Detail2 : Window
    {
        private readonly DetailViewModel _detailVM;

        private readonly DetailService _service;

        
        public Detail2(int houseId)
        {
            InitializeComponent();
            //이미지 작업
            _detailVM = new DetailViewModel()
            {
                ImagePaths = GetFilteredImages(houseId)
            };
            _service = new DetailService(_detailVM);
            LoadHouse(houseId);

            // 두 개의 ViewModel을 하나로 묶어서 DataContext 설정
            DataContext = _detailVM;

            

            // Units 속성 업데이트
            LoadUnits(houseId);
   
        }
        private string[] GetFilteredImages(int houseId)
        {
            string[] imageFiles = GlobalData.ImageFiles;

            string houseIdPrefix = houseId.ToString("D2");
            return imageFiles.Where(file => Path.GetFileNameWithoutExtension(file).StartsWith($"{houseIdPrefix}-"))
                             .ToArray();
        }

        private async void LoadUnits(int houseId)
        {
            await _service.GetUnitsByHouseId(houseId);
        }

        private async void LoadHouse(int houseId)
        {
            await _service.GetHousebyId(houseId);
        }
    }
}
