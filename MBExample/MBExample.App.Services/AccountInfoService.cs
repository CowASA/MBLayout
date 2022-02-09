using MBExample.App.Services.Interfaces;
using MBExample.App.Shared.Models;
using MBExample.App.Shared.Responses;
using Newtonsoft.Json;

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
            var response = await _httpClient.GetStringAsync($"https://algoindexer.algoexplorerapi.io/v2/accounts/{id}");

            var accountInfo = JsonConvert.DeserializeObject<AccountInfo>(response);

            return accountInfo;
            
            //TODO: Catch errors
        }
    }
}
