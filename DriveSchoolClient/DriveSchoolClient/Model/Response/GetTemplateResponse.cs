using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchoolClient.Model.Response
{
    public class GetTemplateResponse
    {
        public long biotype { get; set; }
        public long length {  get; set; }
        public string template { get; set; }
    }
}
