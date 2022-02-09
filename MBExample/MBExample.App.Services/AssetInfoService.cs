using MBExample.App.Services.Interfaces;
using MBExample.App.Shared.Models;
using Newtonsoft.Json;

namespace MBExample.App.Services
{
    public class AssetInfoService : IAssetInfo
    {
        private readonly HttpClient _httpClient;

        public AssetInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AssetInfo>> GetAllAssets()
        {
            var response = await _httpClient.GetStringAsync($"https://algoindexer.algoexplorerapi.io/v2/assets?include-all=false");

            List<AssetInfo> assetInfo = JsonConvert.DeserializeObject<List<AssetInfo>>(response);

            return assetInfo;
        }

        public async Task<AssetInfo> GetAssetInfoByIdAsync(string id)
        {
            var response = await _httpClient.GetStringAsync($"https://algoindexer.algoexplorerapi.io/v2/assets?include-all=false&asset-id={id}");

            var assetInfo = JsonConvert.DeserializeObject<AssetInfo>(response);

            return assetInfo;

            //TODO: Catch errors
        }

        public Task<AssetInfo> GetAssetInfoByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
