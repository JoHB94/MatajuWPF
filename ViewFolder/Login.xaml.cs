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
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void JoinBtn_Click(object sender, RoutedEventArgs e)
        {
            Join join = new Join();
            join.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            join.ShowDialog();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.LoginModel.Password = (sender as PasswordBox)?.Password;
            }
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Position = TimeSpan.Zero; // 동영상의 재생 위치를 처음으로
                mediaElement.Play(); // 다시 재생
            }
        }
    }
}
