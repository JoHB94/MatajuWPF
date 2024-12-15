using Mataju.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Windows;


namespace Mataju.VMFolder
{
    internal class ListViewModel : ViewModelBase
    {
        private List<HouseModel> _houses = new List<HouseModel>();

        public List<HouseModel> Houses { 
            get => _houses; 
            set
            {
                if (_houses != value)
                {
                    _houses = value;
                    OnPropertyChanged(nameof(Houses));
                }
            }
        }

        public async Task GetHouses()
        {
            //API 엔드 포인트
            string apiUri = "http://localhost:5236/api/Admin/seed-houses";

            try
            {
                HttpResponseMessage responseMessage = await HttpManager.GetAsync(apiUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseContent);

                    _houses = json["houses"]?.ToObject<List<HouseModel>>();
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
