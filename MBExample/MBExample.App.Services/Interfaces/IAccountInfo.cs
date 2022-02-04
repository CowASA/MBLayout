using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBExample.App.Shared.Models;
using MBExample.App.Shared.Responses;

namespace MBExample.App.Services.Interfaces
{
    public interface IAccountInfo
    {
        Task<ApiResponse<AccountInfo>> GetAccountInfoAsync(string? query = null, int pageNumber = 1, int pageSize = 10);

        Task<AccountInfo> GetAccountInfoByIdAsync(string id);
    }
}
