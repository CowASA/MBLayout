using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBExample.App.Shared.Responses
{
    public class ApiErrorResponse
    {
        public Data data { get; set; }
        public string message { get; set; }
    }

    public class Data
    {
    }
}
