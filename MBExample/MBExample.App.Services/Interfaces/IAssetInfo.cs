using MBExample.App.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBExample.App.Services.Interfaces
{
    public interface IAssetInfo
    {
        Task<List<AssetInfo>> GetAllAssets();

        Task<AssetInfo> GetAssetInfoByIdAsync(string id);

        Task<AssetInfo> GetAssetInfoByNameAsync(string name);
    }
}
