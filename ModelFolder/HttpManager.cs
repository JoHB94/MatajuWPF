﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Mataju.ModelFolder
{
    public static class HttpManager
    {
        private static readonly HttpClient _httpClient = new HttpClient();

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
    }
}
