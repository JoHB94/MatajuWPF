using Mataju.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using Mataju.Properties;
using System.Windows.Input;

namespace Mataju.VMFolder
{
    public class ListViewModel : ViewModelBase
    {
        //Card Observable
        private ObservableCollection<CardModel> _cards = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> Cards
        {
            get => _cards;
            set
            {
                if (_cards != value)
                {
                    _cards = value;
                    OnPropertyChanged(nameof(Cards));
                    // Cards 변경 시 FilteredCards 갱신
                    OnPropertyChanged(nameof(FilteredCards));
                    OnPropertyChanged(nameof(Provinces));
                }
            }
        }

        //ComboBox 읽기 전용
        private string _selectedProvince ="전체";
        public string SelectedProvince
        {
            get => _selectedProvince;
            set
            {
                if (_selectedProvince != value)
                {
                    _selectedProvince = value;
                    OnPropertyChanged(nameof(SelectedProvince));
                    // SelectedProvince 변경 시 FilteredCards 갱신
                    OnPropertyChanged(nameof(FilteredCards));
                }
            }
        }

        // ComboBox에 바인딩할 Province 리스트
        public ObservableCollection<string> Provinces
        {
            get
            {
                // "전체" 항목 추가 및 기존 Province 리스트와 병합
                var provincesWithAll = new ObservableCollection<string> { "전체" };
                foreach (var province in Cards.Select(card => card.Province).Distinct().OrderBy(p => p))
                {
                    provincesWithAll.Add(province);
                }
                return provincesWithAll;
            }
        }

        // SelectedProvince에 따라 필터링된 Cards 반환
        public ObservableCollection<CardModel> FilteredCards
        {
            get
            {
                if (SelectedProvince == "전체")
                {
                    // 전체 Province 반환
                    return Cards;
                }
                else
                {
                    // 선택된 Province에 해당하는 Cards만 반환
                    return new ObservableCollection<CardModel>(
                        Cards.Where(card => card.Province == SelectedProvince)
                    );
                }
            }
        }

        //HouseModel 변경감지 => 삭제 해 주세요
        private HouseModel _selectedHouse;
        public HouseModel SelectedHouse
        {
            get => _selectedHouse;
            set
            {
                if (_selectedHouse != value)
                {
                    _selectedHouse = value;
                    OnPropertyChanged(nameof(SelectedHouse)); // 변경 통지
                }
            }
        }
    }
}
