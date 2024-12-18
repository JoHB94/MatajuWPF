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

namespace Mataju.CompFolder
{
    /// <summary>
    /// EstimateTable.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EstimateTable : UserControl
    {
        public EstimateTable()
        {
            InitializeComponent();
        }


        // ViewModel을 바인딩하기 위한 속성
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(EstimateTableViewModel), typeof(EstimateTable));

        public EstimateTableViewModel ViewModel
        {
            get { return (EstimateTableViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}
