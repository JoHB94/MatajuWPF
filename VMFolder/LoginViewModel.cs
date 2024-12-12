using Mataju.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Security.RightsManagement;
using Newtonsoft.Json.Linq;

namespace Mataju.VMFolder
{
    internal class LoginViewModel : ViewModelBase
    {
        public static string token = null;
        public static string nickname = null;

        private LoginModel _loginModel = new LoginModel();

        public LoginModel LoginModel 
        {
            get => _loginModel;
            set
            {
                if (_loginModel != value)
                {
                    _loginModel = value;
                    OnPropertyChanged(nameof(LoginModel));
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        public async Task LoginAsync()
        {

            //API 엔드포인트
            string apiUrl = "http://localhost:5236/api/User/login";

            try
            {
                HttpResponseMessage responseMessage = await HttpManager.PostAsync(apiUrl, LoginModel);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseContent);
                    token = json["token"]?.ToString();
                    nickname = json["nickname"]?.ToString();
                    Console.WriteLine($"token: {token}");
                    Console.WriteLine($"nickname: {nickname}");

                    Console.WriteLine($"응답: {responseContent}");
                    MessageBox.Show($"안녕하세요, {nickname}님! 로그인에 성공하셨습니다.");
                }
                else
                {
                    string errorContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine($"오류 상태: {responseMessage.StatusCode}, 내용: {errorContent}");
                    MessageBox.Show("로그인 실패");
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
