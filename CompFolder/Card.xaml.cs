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
        }
        /*
        //의존성 프로퍼티 추가 : name, add, img

        // Name 속성
        public static readonly DependencyProperty HouseIdProperty =
            DependencyProperty.Register(nameof(HouseId), typeof(string), typeof(Card), new PropertyMetadata("Default Name"));

        public string HouseId
        {
            get => (string)GetValue(HouseIdProperty);
            set => SetValue(HouseIdProperty, value);
        }

        // Add 속성
        public static readonly DependencyProperty HouseAddProperty =
            DependencyProperty.Register(nameof(HouseAdd), typeof(string), typeof(Card), new PropertyMetadata("Default Address"));

        public string HouseAdd
        {
            get => (string)GetValue(HouseAddProperty);
            set => SetValue(HouseAddProperty, value);
        }

        // Img 속성
        public static readonly DependencyProperty ImgProperty =
            DependencyProperty.Register(nameof(Img), typeof(ImageSource), typeof(Card), new PropertyMetadata(null));

        public ImageSource Img
        {
            get => (ImageSource)GetValue(ImgProperty);
            set => SetValue(ImgProperty, value);
        }*/
    }
}
