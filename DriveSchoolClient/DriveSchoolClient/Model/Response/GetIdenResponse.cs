using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchoolClient.Model.Response
{

    public class GetIdenResponse
    {
        public CardClass card { get; set; }
        public FingerClass finger { get; set; }
    }
    public class FingerClass
    {
        public string nat_id { get; set; }
        public long biotype { get; set; }
        public long enroll_index { get; set; }
        public long quality { get; set; }
        public long witdth { get; set; }
        public long height { get; set; }
        public string jpg_base64 { get; set; }
    }
    public class CardClass
    {
        public string nat_id { get; set; }
        public string title_th { get; set; }
        public string fname_th { get; set; }
        public string mname_th { get; set; }
        public string sname_th { get; set; }
        public string title_en { get; set; }
        public string fname_en { get; set; }
        public string mname_en { get; set; }
        public string sname_en { get; set; }
        public string address_no { get; set; }
        public string address_moo { get; set; }
        public string address_trok { get; set; }
        public string address_soi { get; set; }
        public string address_road { get; set; }
        public string address_tumbol { get; set; }
        public string address_amphor { get; set; }
        public string address_provinice { get; set; }
        public string gender { get; set; }
        public string birthdate { get; set; }
        public string issuer { get; set; }
        public string photo { get; set; }
    }
}
