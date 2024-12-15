using Mataju.ViewFolder;
using Mataju.VMFolder;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace Mataju.CompFolder
{
    /// <summary>
    /// Header.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            // 애플리케이션 재시작
            Process.Start(Application.ResourceAssembly.Location);

            // 현재 애플리케이션 종료
            Application.Current.Shutdown();
        }
    }
}
