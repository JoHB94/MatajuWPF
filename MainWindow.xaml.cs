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
using System.Windows.Navigation;



namespace Mataju
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window

        
    {
        public MainWindow()
        {
            InitializeComponent();

            GlobalData.ImageFiles = LoadResourceFiles();

            // 이미지 파일 확인
            foreach (var file in GlobalData.ImageFiles)
            {
                Console.WriteLine($"Found image: {file}");
            }

        }

        static string[] LoadResourceFiles()
        {
            string resourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");


            Console.WriteLine($"Resource Folder Path: {resourceDirectory}");

            // 이미지 파일 읽기
            return Directory.GetFiles(resourceDirectory, "*.*", SearchOption.TopDirectoryOnly)
                            .Where(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                           file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                           file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                           file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                            .ToArray();
        }
    }
}
