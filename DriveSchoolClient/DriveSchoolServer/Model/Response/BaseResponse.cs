using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchoolServer.Model.Response
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public string error { get; set; }
        public object data { get; set; }

        public T GetData<T>()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data.ToString());
        }

    }
}
