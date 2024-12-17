using Mataju.ModelFolder;
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
        public Detail2(HouseModel houseModel)
        {
            InitializeComponent();
            DataContext = new DetailViewModel(houseModel);

            string[] filteredImages = GetFilteredImages(houseModel.HouseId);

            // DetailViewModel 생성 및 DataContext 설정
            DetailViewModel viewModel = new DetailViewModel(houseModel)
            {
                ImagePaths = filteredImages
            };
            DataContext = viewModel;
        }
        private string[] GetFilteredImages(int houseId)
        {
            string[] imageFiles = GlobalData.ImageFiles;

            string houseIdPrefix = houseId.ToString("D2");
            return imageFiles.Where(file => Path.GetFileNameWithoutExtension(file).StartsWith($"{houseIdPrefix}-"))
                             .ToArray();
        }
    }
}
