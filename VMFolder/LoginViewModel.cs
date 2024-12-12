using Mataju.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mataju.VMFolder
{
    internal class LoginViewModel : ViewModelBase
    {
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
            //LoginCommand = new RelayCommand(async() => await )
        }

        public async Task LoginAsync()
        {

            //API 엔드포인트
            string apiUrl = "";
        }
    }
}
