using Mataju.ModelFolder;
using Mataju.VMFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Mataju.ViewFolder;

namespace Mataju.Service
{
    public class DetailService
    {
        private readonly DetailViewModel detailViewModel;

        public DetailService(DetailViewModel viewModel)
        {
            this.detailViewModel = viewModel;
        }

        public async Task GetHousebyId(int houseId)
        {
            Console.WriteLine("GetHousebyId 호출!");
            //var parameter = detailViewModel.SelectedHouse.HouseId;

            //API 엔드 포인트
            string apiUri = string.Format("http://3.38.45.83/api/House/{0}", houseId);

            try
            {
                HttpResponseMessage responseMessage = await HttpManager.GetAsync(apiUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    HouseModel houseModel = JsonConvert.DeserializeObject<HouseModel>(responseContent);
                    detailViewModel.SelectedHouse = houseModel;
                    Console.WriteLine(detailViewModel.SelectedHouse);
                    

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


        public async Task GetUnitsByHouseId(int houseId)
        {
            //API 엔드 포인트
            string apiUri = string.Format("http://3.38.45.83/api/Unit/house/{0}", houseId);


            try
            {
                HttpResponseMessage responseMessage = await HttpManager.GetAsync(apiUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    List<UnitModel> unitList = JsonConvert.DeserializeObject<List<UnitModel>>(responseContent);
                    //viewModel.Units = new ObservableCollection<UnitModel>(unitList);
                    

                    List<BookingGridModel> bookingGrid = GroupUnitsBySize(unitList);
                    detailViewModel.GroupedUnits = new ObservableCollection<BookingGridModel>(bookingGrid);
                    Console.WriteLine($"GroupedUnit 총 {detailViewModel.GroupedUnits.Count}개 항목.");
                }
                else
                {
                    string errorContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine($"오류 상태: {responseMessage.StatusCode}, 내용: {errorContent}");
                    MessageBox.Show("unit 정보를 불러오는데 실패하였습니다.");
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
        //UnitList => Grid 형식으로 데이터 변환 메소드
        public List<BookingGridModel> GroupUnitsBySize(List<UnitModel> unitList)
        {
            // 사이즈별로 그룹화할 변수 준비
            var grouped = new Dictionary<string, BookingGridModel>
                {
                    { "S", new BookingGridModel { Size = "S", AvailableCount = 0 } },
                    { "M", new BookingGridModel { Size = "M", AvailableCount = 0 } },
                    { "L", new BookingGridModel { Size = "L", AvailableCount = 0 } }
                };

            // unitList에서 각 사이즈별로 Available 상태인 것들을 카운팅하고 가격을 저장
            foreach (var unit in unitList)
            {
                if (unit.Status == "Available")
                {
                    // 해당 사이즈의 AvailableCount를 증가
                    grouped[unit.Size].AvailableCount++;

                    // 가격은 첫 번째로 나오는 가격만 저장하면 되므로, 사이즈에 대해 한 번만 저장
                    if (grouped[unit.Size].Price == 0)
                    {
                        grouped[unit.Size].Price = unit.Price;
                    }
                }
            }

            // 결과를 List로 변환하여 반환
            return grouped.Values.ToList();
        }
    }


}
