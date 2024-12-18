using Mataju.Service;
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
        private readonly ListService listService;
        private readonly ListViewModel _viewModel; 
        public List()
        {
            InitializeComponent();
            _viewModel = new ListViewModel();
            listService = new ListService();
            this.DataContext = _viewModel;
            // 창이 로드되었을 때 비동기적으로 데이터 가져오기
            Loaded += async (s, e) => await Page_LoadedAsync();
        }

        private async Task Page_LoadedAsync()
        {
            try
            {
                // GetHouses 호출
                await listService.GetHouses(_viewModel);
            }
            catch (Exception ex)
            {
                // 오류 발생 시 사용자에게 알림
                Console.WriteLine($"Page_Loaded 오류: {ex.Message}");
                MessageBox.Show("데이터를 불러오는 중 문제가 발생했습니다. 나중에 다시 시도해주세요.");
            }
        }
    }
}
