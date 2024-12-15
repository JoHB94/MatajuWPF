using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Mataju.VMFolder;

namespace Mataju.ModelFolder
{
    public static class HttpManager
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        //POST 요청 메소드
        public static async Task<HttpResponseMessage> PostAsync(string url, object data)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                return await _httpClient.PostAsync(url, content);
            }
            catch (Exception ex)
            {
                // 로깅 또는 기본 예외 처리 (필요 시)
                throw new HttpRequestException($"POST 요청 중 오류 발생: {ex.Message}", ex);
            }
        }

        // GET 요청 메서드
        public static async Task<HttpResponseMessage> GetAsync(string url)
        {
            //Request 헤더에 토큰 추가
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoginViewModel.token);

            try
            {
                return await _httpClient.GetAsync(url);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"GET 요청 중 오류 발생: {ex.Message}", ex);
            }
        }
    }

}
