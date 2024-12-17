using Mataju.ModelFolder;
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
    /// Card.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
            
        }
       
        //의존성 프로퍼티 추가 : name, add, img

        // Name 속성
        public static readonly DependencyProperty ProvinceProperty =
            DependencyProperty.Register(nameof(Province), typeof(string), typeof(Card), new PropertyMetadata("Default Province"));

        public string Province
        {
            get => (string)GetValue(ProvinceProperty);
            set => SetValue(ProvinceProperty, value);
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
        public static readonly DependencyProperty ImgPathProperty =
            DependencyProperty.Register(nameof(ImgPath), typeof(ImageSource), typeof(Card), new PropertyMetadata(null));

        public ImageSource ImgPath
        {
            get => (ImageSource)GetValue(ImgPathProperty);
            set => SetValue(ImgPathProperty, value);
        }

        //CardClick이벤트 리스너
        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            //클릭시 command 실행
            var cardModel = (CardModel)this.DataContext;
            if (cardModel.CardClickCommand.CanExecute(cardModel.HouseId)) // 파라미터 전달
            {
                cardModel.CardClickCommand.Execute(cardModel.HouseId); // 파라미터 전달
            }
        }
        

    }
}
