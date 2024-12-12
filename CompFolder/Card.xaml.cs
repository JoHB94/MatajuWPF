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
    /// Card.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
            this.DataContext = this; // UserControl 자체를 DataContext로 설정
        }

        //의존성 프로퍼티 추가 : name, add, img

        // Name 속성
        public static readonly DependencyProperty HouseNameProperty =
            DependencyProperty.Register(nameof(HouseName), typeof(string), typeof(Card), new PropertyMetadata("Default Name"));

        public string HouseName
        {
            get => (string)GetValue(HouseNameProperty);
            set => SetValue(HouseNameProperty, value);
        }

        // Add 속성
        public static readonly DependencyProperty AddProperty =
            DependencyProperty.Register(nameof(Add), typeof(string), typeof(Card), new PropertyMetadata("Default Address"));

        public string Add
        {
            get => (string)GetValue(AddProperty);
            set => SetValue(AddProperty, value);
        }

        // Img 속성
        public static readonly DependencyProperty ImgProperty =
            DependencyProperty.Register(nameof(Img), typeof(ImageSource), typeof(Card), new PropertyMetadata(null));

        public ImageSource Img
        {
            get => (ImageSource)GetValue(ImgProperty);
            set => SetValue(ImgProperty, value);
        }
    }
}
