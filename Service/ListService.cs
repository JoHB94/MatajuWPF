using Mataju.ModelFolder;
using Mataju.VMFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Mataju.ViewFolder;

namespace Mataju.Service
{
    public class ListService
    {
        //Command 부분

        public async Task GetHouses(ListViewModel listViewModel)
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

                    List<CardModel> cardList = new List<CardModel>();
                    for (int i = 0; i < housesList.Count; i++)
                    {
                        var house = housesList[i];
                        // HouseId 기반 이미지 이름 패턴 생성 (예: "01-1", "02-1", ...)
                        string targetPrefix = (i + 1).ToString("D2") + "-1";
                        // 해당 HouseId에 맞는 첫 번째 이미지 찾기
                        string matchedImage = GlobalData.ImageFiles.FirstOrDefault(file =>
                            Path.GetFileNameWithoutExtension(file).StartsWith(targetPrefix));

                        var card = new CardModel
                        {
                            HouseId = house.HouseId,
                            HouseAdd = house.HouseAdd,
                            Province = house.Province,
                            ImgPath = matchedImage, // 이미지가 있으면 매핑, 없으면 null
                            CardClickCommand = new RelayCommand(() =>
                            {
                                var detail = new Detail2(house.HouseId); // Detail2 인스턴스 생성
                                detail.ShowDialog();       // ShowDialog 호출로 새 창 띄우기
                            })
                        };
                        //card.CardClickCommand = new RelayCommand<string>(parameter => GetHousebyId(parameter));
                        Console.WriteLine(card.CardClickCommand);
                        cardList.Add(card);

                    }

                    // ObservableCollection에 바인딩
                    listViewModel.Cards = new ObservableCollection<CardModel>(cardList);

                    Console.WriteLine($"CardModel 변환 완료. 총 {listViewModel.Cards.Count}개 항목.");
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
            catch (Exception ex)
            {
                //알수 없는 오류
                Console.WriteLine($"예외 발생: {ex.Message}");
                MessageBox.Show("알 수 없는 오류가 발생했습니다.");
            }
        }
    }
}
