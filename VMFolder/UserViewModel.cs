using Mataju.ModelFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Input;
using System.Windows;


namespace Mataju.VMFolder
{
    internal class UserViewModel : ViewModelBase
    {
        private User _user = new User();
        public User User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public Action CloseWindow { get; set; }

        public ICommand JoinCommand { get; }

        public UserViewModel()
        {
            //JoinCommand = new RelayCommand(async () => await JoinAsync(), () => CanJoin());
            JoinCommand = new RelayCommand(async () => await JoinAsync());
        }

        private bool CanJoin()
        {
            return !string.IsNullOrEmpty(User?.Name) && !string.IsNullOrEmpty(User?.Password);
        }
        public async Task JoinAsync()
        {
     
            //API 엔드포인트
            string apiUrl = "http://3.38.45.83/api/User/register";
            string aws_apiUrl = "http://15.164.226.158/api/User/register";
            try
            {
                 //POST 요청 보내고 응답 받기
                HttpResponseMessage responseMessage = await HttpManager.PostAsync(aws_apiUrl, User);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine($"응답: {responseContent}");
                    MessageBox.Show("사용자 등록 성공!");
                    // Window 닫기
                    CloseWindow?.Invoke();
                }
                else
                {
                    string errorContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine($"오류 상태: {responseMessage.StatusCode}, 내용: {errorContent}");
                    MessageBox.Show("사용자 등록 실패");
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"네트워크 오류: {ex.Message}");
                MessageBox.Show("서버에 연결할 수 없습니다. 나중에 다시 시도하세요.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외 발생: {ex.Message}");
                MessageBox.Show("알 수 없는 오류가 발생했습니다.");
            }

        }

    }
}
