using MBExample.App.Services.Exceptions;
using MBExample.App.Services.Interfaces;
using MBExample.App.Shared.Models;
using MBExample.App.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MBExample.App.Services
{
    public class AccountInfoService : IAccountInfo
    {
        private readonly HttpClient _httpClient;

        public AccountInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ApiResponse<AccountInfo>> GetAccountInfoAsync(string? query = null, int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountInfo> GetAccountInfoByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"https://algoindexer.algoexplorerapi.io/v2/accounts/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AccountInfo>();
                return result;
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }
        }
    }
}
