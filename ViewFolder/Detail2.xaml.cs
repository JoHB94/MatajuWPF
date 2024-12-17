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
        private readonly DetailViewModel _viewModel;
        private readonly ListViewModel _viewModel2;
        private readonly ListCombinedDetailViewModel _viewModel3;

        private readonly DetailService _service;

        
        public Detail2(HouseModel houseModel)
        {
            InitializeComponent();
            //이미지 작업
            string[] filteredImages = GetFilteredImages(houseModel.HouseId);
            // ViewModel 초기화
            _viewModel = new DetailViewModel(houseModel);
            
            _viewModel2 = new ListViewModel();
            // ListCombinedDetailViewModel 초기화 (UI에 뿌려질 데이터)
            _viewModel3 = new ListCombinedDetailViewModel(_viewModel, _viewModel2)
            {
                ImagePaths = filteredImages
            }; 

            // 두 개의 ViewModel을 하나로 묶어서 DataContext 설정
            DataContext = _viewModel3;

            // Service 초기화
            _service = new DetailService();

            // Units 속성 업데이트
            LoadUnits();
   
        }
        private string[] GetFilteredImages(int houseId)
        {
            string[] imageFiles = GlobalData.ImageFiles;

            string houseIdPrefix = houseId.ToString("D2");
            return imageFiles.Where(file => Path.GetFileNameWithoutExtension(file).StartsWith($"{houseIdPrefix}-"))
                             .ToArray();
        }

        private async void LoadUnits()
        {
            await _service.GetUnitsByHouseId( _viewModel);
        }
    }
}
