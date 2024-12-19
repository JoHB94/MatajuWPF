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
using System.Windows.Shapes;

namespace Mataju.ViewFolder
{
    /// <summary>
    /// Join.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Join : Window
    {
        public Join()
        {
            InitializeComponent();
            var viewModel = new UserViewModel();
            DataContext = viewModel;

            // ViewModel의 CloseWindow Action을 창 닫기로 연결
            viewModel.CloseWindow = () => this.Close();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
