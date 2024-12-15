using Mataju.VMFolder;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mataju.ViewFolder
{
    /// <summary>
    /// List.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class List : Window
    {
        private ListViewModel _viewModel = new ListViewModel();
        public List()
        {
            InitializeComponent();
            this.DataContext = _viewModel;

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // GetHouses 메서드 호출
            await _viewModel.GetHouses();
        }
    }
}
