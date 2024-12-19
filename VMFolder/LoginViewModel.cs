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
using Mataju.ViewFolder;
using System.Windows.Navigation;

namespace Mataju.VMFolder
{
    public class LoginViewModel : ViewModelBase
    {
        public static string token = null;
        
        private static string _nickname;
        public static string Nickname
        {
            get => _nickname;
            set
            {
                if (_nickname != value)
                {
                    _nickname = value;
                    OnStaticPropertyChanged(nameof(Nickname));
                }
            }
        }
        public static int userId = -1;

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

        public Uri VideoPath
        {
            get
            {
                if (!string.IsNullOrEmpty(GlobalData.VideoFiles))
                {
                    return new Uri(GlobalData.VideoFiles, UriKind.Absolute);
                }
                return null;
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
            string apiUrl = "http://3.38.45.83/api/User/login";

            try
            {
                HttpResponseMessage responseMessage = await HttpManager.PostAsync(apiUrl, LoginModel);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseContent);
                    token = json["token"]?.ToString();
                    Nickname = json["nickname"]?.ToString();
                    userId = Convert.ToInt32(json["userId"] ?? 0);
                    Console.WriteLine($"token: {token}");
                    Console.WriteLine($"nickname: {Nickname}");

                    Console.WriteLine($"응답: {responseContent}");
                    MessageBox.Show($"안녕하세요, {Nickname}님! 로그인에 성공하셨습니다.");
                    
                    List list = new List();
                    list.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    list.Show();
                    Application.Current.Windows[0]?.Close();

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
