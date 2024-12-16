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

namespace Mataju.VMFolder
{
    internal class ListViewModel : ViewModelBase
    {

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
                }
            }
        }


        public async Task GetHouses()
        {
            Console.WriteLine("GetHouses 호출!");
            //API 엔드 포인트
            string apiUri = "http://3.38.45.83/api/House/all";

            //string basePath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                HttpResponseMessage responseMessage = await HttpManager.GetAsync(apiUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    List<HouseModel> housesList = JsonConvert.DeserializeObject<List<HouseModel>>(responseContent);

                    //이미지 파일 경로 읽기
                    string resourceFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Mataju\Resources");
                    Console.WriteLine($"{apiUri}/{resourceFolder}");

                    string[] imageFiles = Directory.GetFiles(resourceFolder, "*.*", SearchOption.TopDirectoryOnly)
                                                   .Where(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                                  file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                                  file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                                  file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                                                   .ToArray();
                    // HouseModel -> CardModel변경
                    List<CardModel> cardList = new List<CardModel>();
                    for (int i = 0; i < housesList.Count; i++)
                    {
                        var house = housesList[i];
                        // HouseId 기반 이미지 이름 패턴 생성 (예: "01-1", "02-1", ...)
                        string targetPrefix = (i + 1).ToString("D2") + "-1";
                        // 해당 HouseId에 맞는 첫 번째 이미지 찾기
                        string matchedImage = imageFiles.FirstOrDefault(file =>
                            Path.GetFileNameWithoutExtension(file).StartsWith(targetPrefix));

                        var card = new CardModel
                        {
                            HouseId = house.HouseId,
                            HouseAdd = house.HouseAdd,
                            Province = house.Province,
                            ImgPath = matchedImage // 이미지가 있으면 매핑, 없으면 null
                        };
                        cardList.Add(card);
                    }

                    // ObservableCollection에 바인딩
                    Cards = new ObservableCollection<CardModel>(cardList);
                    Console.WriteLine($"CardModel 변환 완료. 총 {Cards.Count}개 항목.");
                }
                else
                {
                    string errorContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine($"오류 상태: {responseMessage.StatusCode}, 내용: {errorContent}");
                    MessageBox.Show("house 정보를 불러오는데 실패하였습니다.");
                }
            }
            catch (HttpRequestException ex)
            {
                //네트워크 오류
                Console.WriteLine($"네트워크 오류: {ex.Message}");
                MessageBox.Show("서버에 연결할 수 없습니다. 나중에 다시 시도하세요.");
            }
            catch(Exception ex) 
            {
                //알수 없는 오류
                Console.WriteLine($"예외 발생: {ex.Message}");
                MessageBox.Show("알 수 없는 오류가 발생했습니다.");
            }
        }
    }
}
