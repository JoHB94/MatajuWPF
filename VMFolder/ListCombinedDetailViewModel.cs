using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mataju.VMFolder
{
    public class ListCombinedDetailViewModel : ViewModelBase
    {
        public ListViewModel ListViewModel { get; set; }
        public DetailViewModel DetailViewModel { get; set; }

        public ListCombinedDetailViewModel(DetailViewModel detailViewModel, ListViewModel listViewModel)
        {
            DetailViewModel = detailViewModel;
            ListViewModel = ListViewModel;
        }

        private string[] _imagePaths;
        // ImagePaths 속성 추가
        public string[] ImagePaths
        {
            get => _imagePaths;
            set
            {
                if (_imagePaths != value)
                {
                    _imagePaths = value;
                    OnPropertyChanged(nameof(ImagePaths));
                }
            }
        }
    }
}
